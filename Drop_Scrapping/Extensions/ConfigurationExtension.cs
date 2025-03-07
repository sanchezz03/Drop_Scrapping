﻿using Drop_Scrapping.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Drop_Scrapping.Extensions;

public static class ConfigurationExtension
{
    public static IHostBuilder AddConfiguration(this IHostBuilder hostBuilder, bool useFile = true)
    {
        if (useFile)
        {
            hostBuilder.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
            {
                configurationBuilder.Sources.Clear();
                var env = hostingContext.HostingEnvironment;

                configurationBuilder
                     .SetBasePath(env.ContentRootPath)
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables()
                     .Build();
            });
        }

        hostBuilder.ConfigureServices((hostBuilder, services) =>
        {
            var configurationOptions = TypesHelper.GetTypesImplementingGenericInterface(typeof(IConfigureOptions<>));
            configurationOptions.ToList().ForEach(options => services.ConfigureOptions(options));
        });

        return hostBuilder;
    }
}
