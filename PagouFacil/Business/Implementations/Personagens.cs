using PagouFacil.Business.Interfaces;
using PagouFacil.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PagouFacil.Business.Implementations
{
    public class Personagens : IPersonagens
    {
        private readonly IService _service;

        public Personagens(IService service)
        {
            _service = service;
        }

        public async Task<SucessDTO> getPersonagensMarvel()
        {
            /* Os campos comics, series, stories, events são listas que contêm items, porem, precisamos
               apenas do campo name de cada item da lista items. */

            var sucess = new SucessDTO();
            try
            {
                var marverResult = await _service.getMarvelPersonages();

                if (typeof(MarvelDTO).GetProperties().All(x => x.GetValue(marverResult) == null))
                    throw new Exception("Falha ao consultar os dados da API da Marvel. Nenhum dado foi obtido.");

                var comics = marverResult?.data?.results?.Where(x => x.comics.items.Any()).Select(x => x.comics.items.FirstOrDefault().name).ToList();
                var stories = marverResult?.data?.results?.Where(x => x.stories.items.Any()).Select(x => x.stories.items.FirstOrDefault().name).ToList();
                var events = marverResult?.data?.results?.Where(x => x.events.items.Any()).Select(x => x.events.items.FirstOrDefault().name).ToList();
                //var series = marverResult?.data?.results?.Where(x => x.series.items.Any()).Select(x => x.series.items.FirstOrDefault().name).ToList();
                
                //salvar arquivo TXT no diretório da aplicação 

                sucess.setSucess();
                return sucess;
            }
            catch (Exception e)
            {
                sucess.setFailure(e.Message);
                return sucess;
            }
        }
    }
}
