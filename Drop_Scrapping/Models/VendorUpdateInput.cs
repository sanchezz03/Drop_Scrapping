using Drop_Scrapping.Enums;
using System.Text.Json.Serialization;

namespace Drop_Scrapping.Models;

public class VendorUpdateInput
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("devices")]
    public List<DeviceTypeEnum> Devices { get; set; }

    [JsonPropertyName("homepage")]
    public string HomePage { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("logo")]
    public AttachmentInputTypeUpdate Logo { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("vehicles")]
    public List<VehicleTypeEnum> Vehicles { get; set; }
}
