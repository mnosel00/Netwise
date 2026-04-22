using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Domain.Interfaces.Files
{
    public interface IFileCreater
    {
        Task CreateContent(string file, string content, CancellationToken cancellationToken = default);
    }
}
