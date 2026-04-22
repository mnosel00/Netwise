using Microsoft.Extensions.Logging;
using Netwise.Domain.Interfaces.Files;

namespace Netwise.Infrastructure.Files
{
    public sealed class FileCreater : IFileCreater
    {
        private readonly ILogger<FileCreater> _logger;

        public FileCreater(ILogger<FileCreater> logger)
        {
            _logger = logger;
        }
        public async Task CreateContent(string file, string content, CancellationToken cancellationToken = default)
        {
            try
            {
                var path = Path.GetDirectoryName(file);

                if(!string.IsNullOrWhiteSpace(path))
                {
                    Directory.CreateDirectory(path);
                }

                await using var stream = new FileStream(file, FileMode.Append);
                await using var writer = new StreamWriter(stream);
                await writer.WriteLineAsync(content);
                await writer.FlushAsync(cancellationToken);
            }
            catch (IOException ex)
            {
                _logger.LogError(ex, "I/O error");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "File error");
                throw;
            }
            
        }
    }
}
