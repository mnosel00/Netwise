using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Netwise.Domain.Interfaces.CatFact;

namespace Netwise.ConsoleApp
{
    public sealed class CatFactRun : BackgroundService
    {
        private readonly ICatFactService _catFactService;
        private readonly ILogger<CatFactRun> _logger;

        public CatFactRun(ICatFactService catFactService, ILogger<CatFactRun> logger)
        {
            _catFactService = catFactService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await _catFactService.StartAsync("catfacts.txt", stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing the cat fact service.");
            }
        }
    }
}
