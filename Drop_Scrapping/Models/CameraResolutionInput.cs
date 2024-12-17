using Newtonsoft.Json;

namespace Drop_Scrapping.Models;

public class CameraResolutionInput
{
    [JsonProperty("fps")]
    public float Fps { get; set; }

    [JsonProperty("length")]
    public float Length { get; set; }

    [JsonProperty("width")]
    public float Width { get; set; }
}
