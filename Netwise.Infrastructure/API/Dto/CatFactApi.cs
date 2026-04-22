using System.Text.Json.Serialization;

namespace Netwise.Infrastructure.API.Dto
{
    internal sealed record CatFactApi
        (
            [property: JsonPropertyName("fact")] string? Fact,
            [property: JsonPropertyName("length")] int? Length
        );
}
