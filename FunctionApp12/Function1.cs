using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApp12
{
    public  class Function1
    {
        ISynapseLogicAppService _logicAppService;
        public Function1(ISynapseLogicAppService logicAppService)
        { 
            _logicAppService = logicAppService;
        }

        [Function("TriggerSynapse")]
        public  async Task<HttpResponseData> CallLogicApp(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestData req,FunctionContext ctx)
        {
           var log =req.FunctionContext.GetLogger("Function1");
            log.LogInformation("C# HTTP trigger function processed a request.");
        var a= ctx.GetLogger("as");
            a.LogDebug("asa");
            var expectedAuth = Environment.GetEnvironmentVariable("ExpectedAuth");
           var basicauth= req.Headers.GetValues("Authorization").FirstOrDefault();

            if (basicauth == null || basicauth != expectedAuth)
            {
               return req.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
               
            }
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<LogicAppRequest>(requestBody);
            string uri = Environment.GetEnvironmentVariable("LogicAppUri");
          var logicAppres= await  _logicAppService.StartPipeline(uri,data);
           
            var res = req.CreateResponse(logicAppres.StatusCode);
            res.WriteString(await logicAppres.Content.ReadAsStringAsync());
            return res;
        }
    }
}
