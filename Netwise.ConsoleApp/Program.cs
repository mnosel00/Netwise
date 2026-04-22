using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Netwise.Domain.Interfaces.CatFact;
using Netwise.Infrastructure.API;
using Netwise.Infrastructure.Services;

var host = Host.CreateDefaultBuilder(args).ConfigureServices((context,services)=>
{
    services.AddHttpClient<ICatFactClient, CatFactHttpClient>(client =>
    {
        client.BaseAddress = new Uri("https://catfact.ninja/");
        client.Timeout = TimeSpan.FromSeconds(10);
    });

    services.AddSingleton<ICatFactService, CatFactService>();
})
    .Build();

var service = host.Services.GetRequiredService<ICatFactService>();
await service.StartAsync("catfacts.txt");

Console.WriteLine("Done.");
