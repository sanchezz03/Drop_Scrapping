namespace Drop_Scrapping.Services.Interfaces;

public interface IDocumentAnalyzeService
{
    Task AnalyzeDocumentAsync(string modelId, Stream documentStream);
}
