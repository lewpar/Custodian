using Custodian.Core.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Custodian.Core.Services
{
    internal class CustodianService : IHostedService
    {
        private ILogger _logger;

        public CustodianService(ILogger<CustodianService> logger) 
        { 
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started CustodianService.");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopped CustodianService.");
        }
    }
}
