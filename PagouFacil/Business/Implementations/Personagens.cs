using PagouFacil.Business.Interfaces;
using PagouFacil.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PagouFacil.Business.Implementations
{
    public class Personagens : IPersonagens
    {
        private readonly IService _service;
        private readonly IConfiguration _configuration;

        public Personagens(IService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        public async Task createFile(MarvelContentLists marvelContentLists)
        {
            var applicationPath = Path.GetDirectoryName(System.Reflection
                     .Assembly.GetExecutingAssembly().Location);

            var targetFile = new SourceAddress(_configuration);
            var fileDestination = applicationPath + @"\" + targetFile.Target;

            using (var streamWriter = File.CreateText(fileDestination))
            {
                streamWriter.WriteLine("******* Comics *******");
                foreach (var comic in marvelContentLists.comics) streamWriter.WriteLine(comic);

                streamWriter.WriteLine("\n");

                streamWriter.WriteLine("******* Stories *******");
                foreach (var storie in marvelContentLists.stories) streamWriter.WriteLine(storie);

                streamWriter.WriteLine("\n");

                streamWriter.WriteLine("******* Events *******");
                foreach (var @event in marvelContentLists.events) streamWriter.WriteLine(@event);

                streamWriter.WriteLine("\n");

                streamWriter.WriteLine("******* Series *******");
                foreach (var serie in marvelContentLists.series) streamWriter.WriteLine(serie);
            }
        }

        public async Task<SucessDTO> getPersonagensMarvel()
        {
            var sucess = new SucessDTO();
            try
            {
                var marverResult = await _service.getMarvelPersonages();

                if (typeof(MarvelDTO).GetProperties().All(x => x.GetValue(marverResult) == null))
                    throw new Exception("Falha ao consultar os dados da API da Marvel. Nenhum dado foi obtido.");

                var comics = marverResult?.data?.results?.Where(x => x.comics.items.Any()).Select(x => x.comics.items.FirstOrDefault().name).ToList();
                var stories = marverResult?.data?.results?.Where(x => x.stories.items.Any()).Select(x => x.stories.items.FirstOrDefault().name).ToList();
                var events = marverResult?.data?.results?.Where(x => x.events.items.Any()).Select(x => x.events.items.FirstOrDefault().name).ToList();
                var series = marverResult?.data?.results?.Where(x => x.series.items.Any()).Select(x => x.series.items.FirstOrDefault().name).ToList();

                await createFile(new MarvelContentLists(comics, stories, events, series));

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
