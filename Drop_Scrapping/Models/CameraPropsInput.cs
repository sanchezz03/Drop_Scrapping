using Drop_Scrapping.Enums;
using Newtonsoft.Json;

namespace Drop_Scrapping.Models;

public class CameraPropsInput
{
    [JsonProperty("auto_gain_control")]
    public string AutoGainControl { get; set; }

    [JsonProperty("back_light_compensation")]
    public string BackLightCompensation { get; set; }

    [JsonProperty("built_in_battery")]
    public BuiltInBatteryInput BuiltInBattery { get; set; }

    [JsonProperty("cable_length_mm")]
    public float CableLengthMm { get; set; }

    [JsonProperty("camera_voltage_v")]
    public RangeInputType CameraVoltageV { get; set; }

    [JsonProperty("compatible_systems")]
    public List<string> CompatibleSystems { get; set; }

    [JsonProperty("connection_interfaces")]
    public List<ConnectionInterfacesEnum> ConnectionInterfaces { get; set; }

    [JsonProperty("current")]
    public List<CurrentInput> Current { get; set; }

    [JsonProperty("digital_noise_reduction")]
    public string DigitalNoiseReduction { get; set; }

    [JsonProperty("electronic_shutter_speed")]
    public List<string> ElectronicShutterSpeed { get; set; }//shutter

    [JsonProperty("field_of_view_deg")]
    public FovInput FieldOfViewDeg { get; set; }//horizontal resolution

    [JsonProperty("housing_material")]
    public string HousingMaterial { get; set; }//housing material

    [JsonProperty("image")]
    public List<string> Image { get; set; }

    [JsonProperty("image_mode")]
    public List<string> ImageMode { get; set; }

    [JsonProperty("image_sensor")]
    public string ImageSensor { get; set; }//Image Sensor

    [JsonProperty("iso")]
    public string Iso { get; set; }

    [JsonProperty("lens")]
    public float Lens { get; set; }//Lens

    [JsonProperty("menu_control")]
    public string MenuControl { get; set; }//menu control

    [JsonProperty("min_illumination_lux")]
    public float MinIlluminationLux { get; set; }

    [JsonProperty("mirror_and_flip")]
    public string MirrorAndFlip { get; set; }//mirror and flip

    [JsonProperty("one_touch_scene_setting")]
    public List<string> OneTouchSceneSetting { get; set; }

    [JsonProperty("resolutions")]
    public List<CameraResolutionInput> Resolutions { get; set; }// Resolutions

    [JsonProperty("screen_formats")]
    public List<string> ScreenFormats { get; set; }

    [JsonProperty("sensitivity_lux")]
    public float SensitivityLux { get; set; }//sensivity

    [JsonProperty("sensor_resolution_mp")]
    public float SensorResolutionMp { get; set; }

    [JsonProperty("signal_systems")]
    public List<SignalSystemsEnum> SignalSystems { get; set; }//Signal system

    [JsonProperty("signal_to_noise_ratio")]
    public string SignalToNoiseRatio { get; set; }

    [JsonProperty("signal_type")]
    public CameraSignalTypeEnum SignalType { get; set; }

    [JsonProperty("storage_humidity_percent")]
    public RangeInputType StorageHumidityPercent { get; set; }

    [JsonProperty("storage_temperature_deg")]
    public RangeInputType StorageTemperatureDeg { get; set; }

    [JsonProperty("white_balance")]
    public string WhiteBalance { get; set; }

    [JsonProperty("wide_dynamic_range")]
    public string WideDynamicRange { get; set; }

    [JsonProperty("working_humidity_percent")]
    public RangeInputType WorkingHumidityPercent { get; set; }

    [JsonProperty("working_temperature_deg")]
    public RangeInputType WorkingTemperatureDeg { get; set; }
}
