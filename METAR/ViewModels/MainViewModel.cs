using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using METAR.Services;
using METAR.Models;

namespace METAR.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly WeatherService _weatherService;

    [ObservableProperty] private string _icaoCode = string.Empty;
    [ObservableProperty] private string _rawText = string.Empty;
    [ObservableProperty] private string _observed = string.Empty;
    [ObservableProperty] private string _wind = string.Empty;
    [ObservableProperty] private string _visibility = string.Empty;
    [ObservableProperty] private string _clouds = string.Empty;
    [ObservableProperty] private string _temperature = string.Empty;
    [ObservableProperty] private string _pressure = string.Empty;
    [ObservableProperty] private string _humidity = string.Empty;
    [ObservableProperty] private string _flightCategory = string.Empty;
    [ObservableProperty] private Color _flightCategoryColor = Colors.Gray;
    [ObservableProperty] private bool _isLoading = false;
    [ObservableProperty] private bool _hasResult = false;
    [ObservableProperty] private string _errorMessage = string.Empty;
    [ObservableProperty] private bool _hasError = false;

    public MainViewModel()
    {
        _weatherService = new WeatherService();
    }

    [RelayCommand]
    private async Task FetchMetar()
    {
        if (string.IsNullOrWhiteSpace(IcaoCode))
        {
            HasError = true;
            ErrorMessage = "Please enter an ICAO code.";
            return;
        }

        IsLoading = true;
        HasResult = false;
        HasError = false;
        ErrorMessage = string.Empty;

        try
        {
            var data = await _weatherService.GetWeather(IcaoCode);

            if (data == null)
            {
                HasError = true;
                ErrorMessage = $"No METAR data found for \"{IcaoCode.ToUpper()}\".";
                return;
            }

            PopulateFields(data);
            HasResult = true;
        }
        catch (Exception ex)
        {
            HasError = true;
            ErrorMessage = $"Something went wrong: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void PopulateFields(MetarData data)
    {
        RawText = data.RawText;
        Observed = string.IsNullOrEmpty(data.Observed) ? "—" : data.Observed;

        Wind = data.Wind != null
            ? $"{data.Wind.Direction} ({data.Wind.Degrees}°) at {data.Wind.SpeedKts} kts" +
              (data.Wind.GustKts > 0 ? $", gusting {data.Wind.GustKts} kts" : "")
            : "—";

        Visibility = data.Visibility != null
            ? $"{data.Visibility.Miles} mi ({data.Visibility.Meters} m)"
            : "—";

        Clouds = data.Clouds?.Count > 0
            ? string.Join(", ", data.Clouds.Select(c => $"{c.Text} at {c.Feet:F0} ft"))
            : "Clear";

        Temperature = data.Temperature != null
            ? $"{data.Temperature.Celsius:F1}°C / {data.Temperature.Fahrenheit:F1}°F"
            : "—";

        Pressure = data.Pressure != null
            ? $"{data.Pressure.Mb:F1} mb / {data.Pressure.Hg:F2} inHg"
            : "—";

        Humidity = data.Humidity != null
            ? $"{data.Humidity}%"
            : "—";

        FlightCategory = string.IsNullOrEmpty(data.FlightCategory) ? "—" : data.FlightCategory;
        FlightCategoryColor = data.FlightCategory switch
        {
            "VFR"  => Color.FromArgb("#2ecc71"),
            "MVFR" => Color.FromArgb("#3498db"),
            "IFR"  => Color.FromArgb("#e74c3c"),
            "LIFR" => Color.FromArgb("#9b59b6"),
            _      => Colors.Gray
        };
    }
}
