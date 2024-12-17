using Newtonsoft.Json;

namespace Drop_Scrapping.Enums;

public enum ConnectionInterfacesEnum
{
    [JsonProperty("MicroUSB")]
    MicroUSB,

    [JsonProperty("Other")]
    Other,

    [JsonProperty("TypeC")]
    TypeC,

    [JsonProperty("USB")]
    USB
}
