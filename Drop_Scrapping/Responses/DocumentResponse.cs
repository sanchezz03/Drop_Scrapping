namespace Drop_Scrapping.Responses;

public class DocumentResponse
{
    public List<Specification> Specifications { get; set; }
    public List<Table> Tables { get; set; } = new();
}
