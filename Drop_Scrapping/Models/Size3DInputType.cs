using Newtonsoft.Json;

namespace Drop_Scrapping.Models;

public class Size3DInputType
{
    [JsonProperty("height_mm")]
    public float HeightMm { get; set; }

    [JsonProperty("length_mm")]
    public float LengthMm { get; set; }

    [JsonProperty("width_mm")]
    public float WidthMm { get; set; }
}
