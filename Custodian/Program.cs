using Custodian.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Custodian
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args).ConfigureLogging(logging =>
            {
                logging.AddConsole();
            }).ConfigureServices(services =>
            {
                services.AddHostedService<CustodianService>();
            }).Build();

            await host.RunAsync();
            await host.WaitForShutdownAsync();
        }
    }
}