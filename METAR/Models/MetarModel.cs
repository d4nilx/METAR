using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace METAR.Models;

public class RootObject
{
    [JsonPropertyName("results")] public int Results { get; set; }
    [JsonPropertyName("data")] public List<MetarData> Data { get; set; } = new();
}

public class MetarData
{
    [JsonPropertyName("icao")] public string Icao { get; set; } = string.Empty;
    [JsonPropertyName("raw_text")] public string RawText { get; set; } = string.Empty;
    [JsonPropertyName("observed")] public string Observed { get; set; } = string.Empty;
    [JsonPropertyName("clouds")] public List<CloudInfo> Clouds { get; set; } = new();
    [JsonPropertyName("humidity")] public int? Humidity { get; set; }
    [JsonPropertyName("pressure")] public PressureInfo? Pressure { get; set; }
    [JsonPropertyName("temperature")] public TemperatureInfo? Temperature { get; set; }
    [JsonPropertyName("wind")] public WindInfo? Wind { get; set; }
    [JsonPropertyName("visibility")] public VisibilityInfo? Visibility { get; set; }
    [JsonPropertyName("flight_category")] public string FlightCategory { get; set; } = string.Empty;
}

public class CloudInfo
{
    [JsonPropertyName("code")] public string Code { get; set; } = string.Empty;
    [JsonPropertyName("feet")] public double Feet { get; set; }
    [JsonPropertyName("meters")] public double Meters { get; set; }
    [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;
}



public class PressureInfo
{
    [JsonPropertyName("hg")] public double Hg { get; set; }
    [JsonPropertyName("mb")] public double Mb { get; set; }
}

public class TemperatureInfo
{
    [JsonPropertyName("celsius")] public double Celsius { get; set; }
    [JsonPropertyName("fahrenheit")] public double Fahrenheit { get; set; }
}

public class WindInfo
{
    [JsonPropertyName("degrees")] public int Degrees { get; set; }
    [JsonPropertyName("direction")] public string Direction { get; set; } = string.Empty;
    [JsonPropertyName("speed_kts")] public int SpeedKts { get; set; }
    [JsonPropertyName("speed_mph")] public int SpeedMph { get; set; }
    [JsonPropertyName("speed_kph")] public int SpeedKph { get; set; }
    [JsonPropertyName("gust_kts")] public int GustKts { get; set; }
}

public class VisibilityInfo
{
    [JsonPropertyName("miles")] public double Miles { get; set; }
    [JsonPropertyName("miles_float")] public double MilesFloat { get; set; }
    [JsonPropertyName("meters")] public double Meters { get; set; }
    [JsonPropertyName("meters_float")] public double MetersFloat { get; set; }
}
