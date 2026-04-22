using Netwise.Domain.Interfaces.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.Files
{
    public sealed class FileCreater : IFileCreater
    {
        public async Task CreateContent(string file, string content, CancellationToken cancellationToken = default)
        {
            var path = Path.GetDirectoryName(file);

            await using var stream = File.Create(file);
            await using var writer = new StreamWriter(stream);
            await writer.WriteLineAsync(content);
            await writer.FlushAsync(cancellationToken);
        }
    }
}
