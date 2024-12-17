using Drop_Scrapping.Enums;
using Newtonsoft.Json;

namespace Drop_Scrapping.Models;

public class CameraSpecifications
{
    [JsonProperty("documents")]
    public List<AttachmentInputType> Documents { get; set; }

    [JsonProperty("homepage")]
    public string HomePage { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("images")]
    public List<AttachmentInputType> Images { get; set; }

    [JsonProperty("market_availability")]
    public MarketAvailabilityEnum MarketAvailability { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("props")]
    public CameraPropsInput Props { get; set; }

    [JsonProperty("published")]
    public bool Published { get; set; }

    [JsonProperty("size")]
    public Size3DInputType Size { get; set; }//Size

    [JsonProperty("tags")]
    public List<string> Tags { get; set; }

    [JsonProperty("type")]
    public DeviceTypeEnum Type { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("videos")]
    public List<AttachmentInputType> Videos { get; set; }

    [JsonProperty("weight_g")]
    public float Weight { get; set; }
}
