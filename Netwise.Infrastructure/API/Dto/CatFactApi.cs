using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.API.Dto
{
    internal sealed record CatFactApi
        (
        [property: JsonPropertyName("fact")] string? Fact,
        [property: JsonPropertyName("length")] int? Length
        );
    
}
