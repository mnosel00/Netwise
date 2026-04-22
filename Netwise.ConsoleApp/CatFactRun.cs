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
        private readonly IConfiguration _configuration;
        private readonly ICatFactService _catFactService;

        public CatFactRun(IConfiguration configuration, ICatFactService catFactService)
        {
            _configuration = configuration;
            _catFactService = catFactService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var filePath = _configuration["FilePath"];
            
            await _catFactService.StartAsync(filePath,stoppingToken);
        }
    }
}
