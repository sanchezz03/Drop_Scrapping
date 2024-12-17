using Drop_Scrapping.Enums;
using Drop_Scrapping.Models;
using Drop_Scrapping.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Drop_Scrapping.Services;

public class CameraSpecificationService : ICameraSpecificationService
{
    public CameraSpecifications BuildCameraSpecifications(Dictionary<string, string> allFields)
    {
        if (allFields == null) throw new ArgumentNullException(nameof(allFields));

        var cameraSpecifications = new CameraSpecifications
        {
            Name = allFields.TryGetValue("Name", out var name) ? name : null,
            MarketAvailability = DetermineMarketAvailability(allFields),
            Weight = float.TryParse(
                allFields.TryGetValue("Net Weight", out var weight) ? weight.Replace("g", "").Trim() : null,
                out var parsedWeight) ? parsedWeight : 0,
            Tags = allFields.TryGetValue("Tags Model", out var tags) ? tags.Split(' ').ToList() : new List<string>(),
            Size = ParseSize(allFields),
            Props = new CameraPropsInput
            {
                ImageSensor = allFields.TryGetValue("Image Sensor", out var imageSensor) ? imageSensor : null,
                FieldOfViewDeg = ParseFov(allFields.TryGetValue("Lens", out var lens) ? lens : null),
                MirrorAndFlip = allFields.TryGetValue("Mirror/Flip", out var mirrorAndFlip) ? mirrorAndFlip : null,
                ScreenFormats = allFields.TryGetValue("Screen Format", out var screenFormat)
                    ? screenFormat.Split('/').Select(x => x.Trim()).ToList()
                    : new List<string>(),
                SignalSystems = ParseSignalSystems(
                    allFields.TryGetValue("Signal System", out var signalSystem) ? signalSystem : null),
                WideDynamicRange = allFields.TryGetValue("WDR", out var wdr) ? wdr : null,
                MenuControl = allFields.TryGetValue("Menu Control", out var menuControl) ? menuControl : null,
                SensitivityLux = float.TryParse(
                    allFields.TryGetValue("Sensitivity", out var sensitivity)
                        ? sensitivity.Replace("mV/Lux-sec", "").Trim()
                        : null,
                    out var parsedSensitivity) ? parsedSensitivity : 0,
                HousingMaterial = allFields.TryGetValue("Housing Material", out var housingMaterial) ? housingMaterial : null
            }
        };

        DisplaySpecifications(cameraSpecifications);

        return cameraSpecifications;
    }

    #region Private methods

    private MarketAvailabilityEnum DetermineMarketAvailability(Dictionary<string, string> allFields)
    {
        if (allFields.TryGetValue("MarketAvailability", out var availability))
        {
            var parts = availability.Split('\n');

            if (parts.Length > 0 && int.TryParse(parts[1], out var quantity) && quantity > 0)
            {
                return MarketAvailabilityEnum.Available;
            }

            if (Enum.TryParse<MarketAvailabilityEnum>(availability, out var marketAvailability))
            {
                return marketAvailability;
            }
        }

        return MarketAvailabilityEnum.Announced;
    }

    private Size3DInputType ParseSize(Dictionary<string, string> allFields)
    {
        if (allFields.TryGetValue("Dimensions", out var dimensions))
        {
            var parts = dimensions.Split('*').Select(x => x.Replace("mm", "").Trim()).ToList();
            if (parts.Count == 3 &&
                float.TryParse(parts[0], out var width) &&
                float.TryParse(parts[1], out var height) &&
                float.TryParse(parts[2], out var length))
            {
                return new Size3DInputType
                {
                    WidthMm = width,
                    HeightMm = height,
                    LengthMm = length
                };
            }
        }

        return null;
    }

    private FovInput ParseFov(string lensData)
    {
        if (string.IsNullOrEmpty(lensData)) return null;

        var match = Regex.Match(lensData, @"FOV D:(\d+)\u00B0 H:(\d+)\u00B0V:(\d+)\u00B0");
        if (match.Success &&
            float.TryParse(match.Groups[1].Value, out var diagonal) &&
            float.TryParse(match.Groups[2].Value, out var horizontal) &&
            float.TryParse(match.Groups[3].Value, out var vertical))
        {
            return new FovInput
            {
                DiagonalFieldOfView = diagonal,
                HorizontalFieldOfView = horizontal,
                VerticalFieldOfView = vertical
            };
        }

        return null;
    }

    private List<SignalSystemsEnum> ParseSignalSystems(string signalData)
    {
        return string.IsNullOrEmpty(signalData)
            ? new List<SignalSystemsEnum>()
            : signalData.Split('/')
                .Select(s => Enum.TryParse<SignalSystemsEnum>(s.Trim(), out var system) ? system : default)
                .Where(s => s != default)
                .ToList();
    }

    private void DisplaySpecifications(CameraSpecifications specs)
    {
        Console.WriteLine("Camera Specifications:");
        Console.WriteLine($"Name: {specs.Name}");
        Console.WriteLine($"Market Availability: {specs.MarketAvailability}");
        Console.WriteLine($"Weight: {specs.Weight}g");
        Console.WriteLine($"Tags: {string.Join(", ", specs.Tags)}");

        if (specs.Size != null)
        {
            Console.WriteLine("Size:");
            Console.WriteLine($"  Width: {specs.Size.WidthMm}mm");
            Console.WriteLine($"  Height: {specs.Size.HeightMm}mm");
            Console.WriteLine($"  Length: {specs.Size.LengthMm}mm");
        }

        Console.WriteLine("Props:");
        Console.WriteLine($"  Image Sensor: {specs.Props.ImageSensor}");
        Console.WriteLine($"  Field of View: Diagonal {specs.Props.FieldOfViewDeg?.DiagonalFieldOfView}, Horizontal {specs.Props.FieldOfViewDeg?.HorizontalFieldOfView}, Vertical {specs.Props.FieldOfViewDeg?.VerticalFieldOfView}");
        Console.WriteLine($"  Mirror and Flip: {specs.Props.MirrorAndFlip}");
        Console.WriteLine($"  Screen Formats: {string.Join(", ", specs.Props.ScreenFormats)}");
        Console.WriteLine($"  Signal Systems: {string.Join(", ", specs.Props.SignalSystems)}");
        Console.WriteLine($"  Wide Dynamic Range: {specs.Props.WideDynamicRange}");
        Console.WriteLine($"  Menu Control: {specs.Props.MenuControl}");
        Console.WriteLine($"  Sensitivity: {specs.Props.SensitivityLux} mV/Lux-sec");
        Console.WriteLine($"  Housing Material: {specs.Props.HousingMaterial}");
    }

    #endregion
}
