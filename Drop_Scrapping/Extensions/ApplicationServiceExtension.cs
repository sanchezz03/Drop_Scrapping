using Drop_Scrapping.Services;
using Drop_Scrapping.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Drop_Scrapping.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IFileService, FileService>()
            .AddScoped<IDocumentAnalyzeService, DocumentAnalyzeService>()
            .AddScoped<ICameraSpecificationService, CameraSpecificationService>();
    }
}
