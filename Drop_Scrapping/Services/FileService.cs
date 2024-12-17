using Drop_Scrapping.Services.Interfaces;

namespace Drop_Scrapping.Services;

public class FileService : IFileService
{
    private readonly IDocumentAnalyzeService _documentAnalyzeService;
    private readonly string _folderPath;
    private readonly string _fileName;

    private const string MODEL_ID = "dron-camera-model";

    public FileService(IDocumentAnalyzeService documentAnalyzeService)
    {
        _documentAnalyzeService = documentAnalyzeService;
        _folderPath = @"D:\Alex\University\ZDIA\masters_degree\1_semester\Practice\Drop_Scrapping\Drop_Scrapping\PdfFiles";
        _fileName = "RunCam Phoenix 2.pdf";
    }

    public async Task GetAnalysedData()
    {
        string filePath = Path.Combine(_folderPath, _fileName);
        using var stream = new FileStream(filePath, FileMode.Open);

        await _documentAnalyzeService.AnalyzeDocumentAsync(MODEL_ID, stream);
    }
}
