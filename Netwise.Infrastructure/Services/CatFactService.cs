using Netwise.Domain.Interfaces.CatFact;
using Netwise.Domain.Interfaces.Files;
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
        private readonly IFileCreater _fileCreater;

        public CatFactService(ICatFactClient catFactClient, IFileCreater fileCreater)
        {
            _catFactClient = catFactClient;
            _fileCreater = fileCreater;
        }

        public async Task StartAsync(string file, CancellationToken cancellationToken = default)
        {
            var fact = await _catFactClient.GetFactAsync(cancellationToken);
            Console.WriteLine($"Fact: {fact.Fact}");
            Console.WriteLine($"Length: {fact.Length}");

            await _fileCreater.CreateContent(file, fact.Fact, cancellationToken);
        }
    }
}
