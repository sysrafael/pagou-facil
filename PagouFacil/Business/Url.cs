using Microsoft.Extensions.Configuration;

namespace PagouFacil.Business
{
    public class Url
    {
        public string BaseUrl { get; private set; }
        public string ApiKey { get; private set; }
        public string Hash { get; private set; }

        public Url(IConfiguration configuration)
        {
            this.BaseUrl = configuration.GetValue<string>("Url:BaseUrl");
            this.ApiKey = configuration.GetValue<string>("Url:ApiKey");
            this.Hash = configuration.GetValue<string>("Url:Hash");
        }
    }
}
