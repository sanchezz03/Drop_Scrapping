using Newtonsoft.Json;

namespace Drop_Scrapping.Enums;

public enum CameraSignalTypeEnum
{
    [JsonProperty("Analog")]
    Analog,

    [JsonProperty("Digital")]
    Digital
}