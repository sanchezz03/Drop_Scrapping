using Drop_Scrapping.Extensions;
using Drop_Scrapping.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Drop_Scrapping;

public class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        var serviceProvider = host.Services;

        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        var fileService = serviceProvider.GetRequiredService<IFileService>();

        await fileService.GetAnalysedData();

        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .AddConfiguration() 
            .ConfigureServices((context, services) =>
            {
                services.AddServices();     
                services.AddLogging(builder => builder.AddConsole());
            });
}