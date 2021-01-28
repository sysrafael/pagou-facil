using Microsoft.AspNetCore.Mvc;
using PagouFacil.Business.Interfaces;
using PagouFacil.DTO;
using System.Threading.Tasks;

namespace PagouFacil.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PagouFacilController
    {
        private readonly IPersonagens _personagens;

        public PagouFacilController(IPersonagens personagens)
        {
            _personagens = personagens;
        }

        [Route("/personagens")]
        [HttpGet]
        public async Task<ActionResult<SucessDTO>> getPersonagens()
        {
            var data = await _personagens.getPersonagensMarvel();
            return data;
        }
    }
}
