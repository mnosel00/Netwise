using Microsoft.Extensions.Logging;
using Netwise.Domain.Interfaces.CatFact;
using Netwise.Domain.Models.CatFact;
using Netwise.Infrastructure.API.Dto;
using System.Text.Json;

namespace Netwise.Infrastructure.API
{
    public sealed class CatFactHttpClient : ICatFactClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CatFactHttpClient> _logger;

        public CatFactHttpClient(HttpClient httpClient, ILogger<CatFactHttpClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<CatFactModel> GetFactAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using var res = await _httpClient.GetAsync("fact", cancellationToken);

                if (!res.IsSuccessStatusCode)
                {
                    _logger.LogError("API failed with {StatusCode}.", res.StatusCode);
                    return null;
                }

                var json = await res.Content.ReadAsStringAsync(cancellationToken);
                var dto = JsonSerializer.Deserialize<CatFactApi>(json);

                if (dto is null || string.IsNullOrWhiteSpace(dto.Fact))
                {
                    _logger.LogError("Data from API is null or empty");
                    return null;
                }

                var length = dto.Length ?? dto.Fact.Length;
                return new CatFactModel(dto.Fact, length);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Network/API error fetch");
                return null;
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "Request timed out while fetch");
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Invalid JSON from API");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error.");
                return null;
            }
        }
    }
}
