using PagouFacil.DTO;
using System.Threading.Tasks;

namespace PagouFacil.Business.Interfaces
{
    public interface IService
    {
        public Task<MarvelDTO> getMarvelPersonages();
    }
}
