using Custodian.Core.Models;
using Custodian.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Custodian.Core.Services
{
    internal class CustodianService : IHostedService
    {
        private ILogger _logger;
        private AppSettings _settings;

        public CustodianService(ILogger<CustodianService> logger, AppSettings settings) 
        { 
            _logger = logger;
            _settings = settings;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started CustodianService.");
            _logger.LogInformation($"Key: {_settings.Key}");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopped CustodianService.");
        }
    }
}
