using Custodian.Core.Models;
using Custodian.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Custodian
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.AddConsole();
            }).ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile(@"Config/config.json");
            }).ConfigureServices(services =>
            {
                services.AddHostedService<CustodianService>();
                services.AddSingleton<AppSettings>();
            }).Build();

            var config = host.Services.GetService<IConfiguration>();
            var settings = host.Services.GetService<AppSettings>();
            if (config != null && settings != null)
            {
                config.Bind(settings);
            }

            await host.RunAsync();
            await host.WaitForShutdownAsync();
        }
    }
}