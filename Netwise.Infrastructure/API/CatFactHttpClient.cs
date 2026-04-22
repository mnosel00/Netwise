using Netwise.Domain.Interfaces.CatFact;
using Netwise.Domain.Models.CatFact;
using Netwise.Infrastructure.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.API
{
    public sealed class CatFactHttpClient : ICatFactClient
    {
        private readonly HttpClient _httpClient;

        public CatFactHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFactModel> GetFactAsync(CancellationToken cancellationToken = default)
        {
            using var res = await _httpClient.GetAsync("fact", cancellationToken);

            var json = await res.Content.ReadAsStringAsync(cancellationToken);
            var dto = JsonSerializer.Deserialize<CatFactApi>(json);

            var length = dto.Length ?? dto.Fact.Length;
            return new CatFactModel(dto.Fact, length);
        }
    }
}
