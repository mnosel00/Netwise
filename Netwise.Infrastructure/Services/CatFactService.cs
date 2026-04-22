using Netwise.Domain.Interfaces.CatFact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.Services
{
    public sealed class CatFactService : ICatFactService
    {
        private readonly ICatFactClient _catFactClient;

        public CatFactService(ICatFactClient catFactClient)
        {
            _catFactClient = catFactClient;
        }

        public Task StartAsync(string file, CancellationToken cancellationToken = default)
        {
            var fact = _catFactClient.GetFactAsync(cancellationToken); 
            return Task.CompletedTask;
        }
    }
}
