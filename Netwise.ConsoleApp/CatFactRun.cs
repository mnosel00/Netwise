using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Netwise.Domain.Interfaces.CatFact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netwise.ConsoleApp
{
    public sealed class CatFactRun : BackgroundService
    {
        private readonly ICatFactService _catFactService;

        public CatFactRun(ICatFactService catFactService)
        {
            _catFactService = catFactService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _catFactService.StartAsync("catfacts.txt", stoppingToken);
        }
    }
}
