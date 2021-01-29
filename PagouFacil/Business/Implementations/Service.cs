using PagouFacil.Business.Interfaces;
using PagouFacil.DTO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace PagouFacil.Business.Implementations
{
    public class Service : IService
    {
        private readonly IConfiguration _configuration;

        public Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<MarvelDTO> getMarvelPersonages()
        {
            var url = new Url(_configuration);
            var urlRequest = url.BaseUrl + url.ApiKey + url.Hash;

            var client = new RestClient(urlRequest);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JsonElement jsonElement = JsonSerializer.Deserialize<dynamic>(response.Content);
                var marvelResult = JsonSerializer.Deserialize<MarvelDTO>(jsonElement.ToString());
                return marvelResult;
            }

            return new MarvelDTO();
        }
    }
}
