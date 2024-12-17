namespace Drop_Scrapping.Responses;

public class Table
{
    public string TableName { get; set; }
    public List<TableRow> Rows { get; set; } = new();
}
