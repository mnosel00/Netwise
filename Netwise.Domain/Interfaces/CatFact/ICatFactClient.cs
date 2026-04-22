using Netwise.Domain.Models.CatFact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Domain.Interfaces.CatFact
{
    public interface ICatFactClient
    {
        Task<CatFactModel> GetFactAsync(CancellationToken cancellationToken = default);
    }
}
