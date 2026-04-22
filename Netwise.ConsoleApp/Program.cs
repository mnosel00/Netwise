using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Netwise.ConsoleApp;
using Netwise.Domain.Interfaces.CatFact;
using Netwise.Domain.Interfaces.Files;
using Netwise.Infrastructure.API;
using Netwise.Infrastructure.Files;
using Netwise.Infrastructure.Services;

var host = Host.CreateDefaultBuilder(args).ConfigureServices((context,services)=>
{
    services.AddHttpClient<ICatFactClient, CatFactHttpClient>(client =>
    {
        client.BaseAddress = new Uri("https://catfact.ninja/");
    });

    services.AddSingleton<ICatFactService, CatFactService>();
    services.AddSingleton<IFileCreater, FileCreater>();
    services.AddHostedService<CatFactRun>();
})
    .Build();
await host.RunAsync();

/*var service = host.Services.GetRequiredService<ICatFactService>();
await service.StartAsync("catfacts.txt");

Console.WriteLine("Done.");*/
