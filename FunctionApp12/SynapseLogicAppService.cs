using Azure;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp12
{
    public interface ISynapseLogicAppService
    {
        public Task<HttpResponseMessage> StartPipeline(string uri,LogicAppRequest body);
    }

   public class SynapseLogicAppService : ISynapseLogicAppService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;
        public SynapseLogicAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
public async  Task<HttpResponseMessage> StartPipeline(string  uri,LogicAppRequest body)
{
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(body)
                , Encoding.UTF8, "application/json");

            var res = await _httpClient.PostAsync(uri, httpContent);
            
            return res;
        }
    }
}
