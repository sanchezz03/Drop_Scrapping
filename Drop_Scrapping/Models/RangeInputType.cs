using Newtonsoft.Json;

namespace Drop_Scrapping.Models;

public class RangeInputType
{
    [JsonProperty("max")]
    public float Max { get; set; }

    [JsonProperty("min")]
    public float Min { get; set; }
}
