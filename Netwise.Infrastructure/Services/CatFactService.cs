using Microsoft.Extensions.Logging;
using Netwise.Domain.Interfaces.CatFact;
using Netwise.Domain.Interfaces.Files;

namespace Netwise.Infrastructure.Services
{
    public sealed class CatFactService : ICatFactService
    {
        private readonly ICatFactClient _catFactClient;
        private readonly IFileCreater _fileCreater;
        private readonly ILogger<CatFactService> _logger;

        public CatFactService(ICatFactClient catFactClient, IFileCreater fileCreater, ILogger<CatFactService> logger)
        {
            _catFactClient = catFactClient;
            _fileCreater = fileCreater;
            _logger = logger;
        }

        public async Task StartAsync(string file, CancellationToken cancellationToken = default)
        {
            var fact = await _catFactClient.GetFactAsync(cancellationToken);

            if (fact is null || string.IsNullOrWhiteSpace(fact.Fact))
            {
                _logger.LogError("fact is null or empty.");
                return;
            }

            try
            {
                Console.WriteLine($"Fact: {fact.Fact}");
                Console.WriteLine($"Length: {fact.Length}");

                await _fileCreater.CreateContent(file, $"{fact.Fact} | Length: {fact.Length}", cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding data to .txt");
            }
        }
    }
}
