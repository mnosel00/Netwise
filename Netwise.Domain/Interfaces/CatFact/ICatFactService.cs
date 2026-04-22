using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Domain.Interfaces.CatFact
{
    public interface ICatFactService
    {
        Task StartAsync(string file, CancellationToken cancellationToken=default);
    }
}
