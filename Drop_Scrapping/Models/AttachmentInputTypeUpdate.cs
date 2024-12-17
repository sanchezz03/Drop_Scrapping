using Newtonsoft.Json;

namespace Drop_Scrapping.Models;

public class AttachmentInputTypeUpdate
{
    [JsonProperty("language")]
    public string Language { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}
