using Newtonsoft.Json;

namespace Drop_Scrapping.Models;

public class BuiltInBatteryInput
{
    [JsonProperty("capacity_mAh")]
    public float CapacityMah { get; set; }
}
