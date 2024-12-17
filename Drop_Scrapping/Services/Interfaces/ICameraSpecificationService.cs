using Drop_Scrapping.Models;

namespace Drop_Scrapping.Services.Interfaces;

public interface ICameraSpecificationService
{
    CameraSpecifications BuildCameraSpecifications(Dictionary<string, string> allFields);
}
