using System.Text.Json;
using METAR.Models;

namespace METAR.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "d1f6956251bc4c28a77d9329394b829d";

    public WeatherService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<MetarData?> GetWeather(string icaoCode)
    {
        string url = $"https://api.checkwx.com/metar/{icaoCode}/decoded?x-api-key={ApiKey}";
        string response = await _httpClient.GetStringAsync(url);
        RootObject? result = JsonSerializer.Deserialize<RootObject>(response);
        return result?.Data?[0];
    }
}
