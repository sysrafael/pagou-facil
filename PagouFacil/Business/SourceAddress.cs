using Microsoft.Extensions.Configuration;

namespace PagouFacil.Business
{
    public class SourceAddress
    {
        public string BaseUrl { get; private set; }
        public string ApiKey { get; private set; }
        public string Hash { get; private set; }
        public string Target { get; private set; }

        public SourceAddress(IConfiguration configuration)
        {
            this.BaseUrl = configuration.GetValue<string>("SourceAddress:BaseUrl");
            this.ApiKey = configuration.GetValue<string>("SourceAddress:ApiKey");
            this.Hash = configuration.GetValue<string>("SourceAddress:Hash");
            this.Target = configuration.GetValue<string>("SourceAddress:Target"); 
        }
    }
}
