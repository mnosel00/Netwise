namespace Netwise.Domain.Interfaces.Files
{
    public interface IFileCreater
    {
        Task CreateContent(string file, string content, CancellationToken cancellationToken = default);
    }
}
