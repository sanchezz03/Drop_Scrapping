using Newtonsoft.Json;

namespace Drop_Scrapping.Models;

public class FovInput
{
    [JsonProperty("diagonal_field_of_view")]
    public float DiagonalFieldOfView { get; set; }

    [JsonProperty("horizontal_field_of_view")]
    public float HorizontalFieldOfView { get; set; }

    [JsonProperty("vertical_field_of_view")]
    public float VerticalFieldOfView { get; set; }
}
