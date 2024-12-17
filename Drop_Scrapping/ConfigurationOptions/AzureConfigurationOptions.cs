using Drop_Scrapping.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Drop_Scrapping.ConfigurationOptions;

public class AzureConfigurationOptions : IConfigureOptions<AzureConfiguration>
{
    private readonly IConfigurationSection _configurationSection;

    public AzureConfigurationOptions(IConfiguration configuration)
    {
        _configurationSection = configuration.GetSection(Constants.CONFIGURATION_SECTION_AZURE);
    }

    public void Configure(AzureConfiguration options)
    {
        options.ApiKey = _configurationSection?
            .GetValue<string>(nameof(AzureConfiguration.ApiKey)) ??
            string.Empty;

        options.Endpoint = _configurationSection?
            .GetValue<string>(nameof(AzureConfiguration.Endpoint)) ??
            string.Empty;
    }
}
