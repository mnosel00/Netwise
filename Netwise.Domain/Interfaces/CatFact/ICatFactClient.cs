using Netwise.Domain.Models.CatFact;

namespace Netwise.Domain.Interfaces.CatFact
{
    public interface ICatFactClient
    {
        Task<CatFactModel> GetFactAsync(CancellationToken cancellationToken = default);
    }
}
