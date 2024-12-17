namespace Drop_Scrapping.Responses;

public class TableRow
{
    public int RowIndex { get; set; }
    public List<TableCell> Cells { get; set; } = new();
}