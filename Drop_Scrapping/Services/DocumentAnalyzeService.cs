using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Drop_Scrapping.ConfigurationModels;
using Drop_Scrapping.Enums;
using Drop_Scrapping.Models;
using Drop_Scrapping.Responses;
using Drop_Scrapping.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Drop_Scrapping.Services;

public class DocumentAnalyzeService : IDocumentAnalyzeService
{
    private readonly ICameraSpecificationService _cameraSpecificationService;
    private readonly DocumentAnalysisClient _client;

    public DocumentAnalyzeService(ICameraSpecificationService cameraSpecificationService, IOptions<AzureConfiguration> azureConfig)
    {
        var config = azureConfig.Value;

        if (string.IsNullOrEmpty(config.ApiKey) || string.IsNullOrEmpty(config.Endpoint))
        {
            throw new ArgumentException("Azure configuration is invalid.");
        }

        var uri = new Uri(config.Endpoint);
        var azureKeyCredential = new AzureKeyCredential(config.ApiKey);

        _client = new DocumentAnalysisClient(uri, azureKeyCredential);
        _cameraSpecificationService = cameraSpecificationService;
    }

    public async Task AnalyzeDocumentAsync(string modelId, Stream documentStream)
    {
        AnalyzeDocumentOperation operation = await _client.AnalyzeDocumentAsync(WaitUntil.Completed, modelId, documentStream);
        AnalyzeResult result = operation.Value;

        var response = new DocumentResponse();

        var documentFields = ProcessFields(result.Documents);
        var tableFields = ConvertTablesToDictionary(result.Tables);
        var allFields = documentFields.Concat(tableFields).ToDictionary(kv => kv.Key, kv => kv.Value);

        var specifications = _cameraSpecificationService.BuildCameraSpecifications(allFields);
    }

    #region Private methods

    private Dictionary<string, string> ProcessFields(IReadOnlyList<AnalyzedDocument> documents)
    {
        var rawData = new Dictionary<string, string>();

        foreach (var document in documents)
        {
            foreach (var field in document.Fields)
            {
                var key = field.Key?.Trim();
                var value = field.Value.Content?.Trim();

                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    rawData[key] = value;
                }
            }
        }

        return rawData;
    }

    private Dictionary<string, string> ConvertTablesToDictionary(IReadOnlyList<DocumentTable> tables)
    {
        var rawData = new Dictionary<string, string>();

        foreach (var table in tables)
        {
            for (int rowIndex = 0; rowIndex < table.RowCount; rowIndex++)
            {
                var cells = table.Cells.Where(c => c.RowIndex == rowIndex).OrderBy(c => c.ColumnIndex).ToList();

                if (cells.Count >= 2)
                {
                    var key = cells[0].Content?.Trim();
                    var value = cells[1].Content?.Trim();

                    if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                    {
                        rawData[key] = value;
                    }
                }
            }
        }

        return rawData;
    }

    #endregion
}

