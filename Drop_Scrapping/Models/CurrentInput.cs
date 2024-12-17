using Newtonsoft.Json;

namespace Drop_Scrapping.Models;

public class CurrentInput
{
    [JsonProperty("ampers")]
    public float Ampers { get; set; }

    [JsonProperty("volts")]
    public float Volts { get; set; }
}
