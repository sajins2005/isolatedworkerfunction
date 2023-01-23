using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace FunctionApp12
{
    public class Program
    {
        public static async Task Main()
        {
          //  FunctionsDebugger.Enable();
            var host = new HostBuilder()
           .ConfigureFunctionsWorkerDefaults(builder =>
            {
                builder.AddApplicationInsights().AddApplicationInsightsLogger();
            })
            .ConfigureServices(service =>
                service.AddSingleton<ISynapseLogicAppService, SynapseLogicAppService>()
                .AddHttpClient<ISynapseLogicAppService, SynapseLogicAppService>())
            .Build();

            await host.RunAsync();
        }
    }
}
