namespace Netwise.Domain.Interfaces.CatFact
{
    public interface ICatFactService
    {
        Task StartAsync(string file, CancellationToken cancellationToken=default);
    }
}
