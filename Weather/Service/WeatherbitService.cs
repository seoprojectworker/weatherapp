using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Weather.Models;

public class WeatherbitService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public WeatherbitService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<WeatherForecast> GetWeatherForecastByPostalCode(string postalCode)
    {
        string apiKey = _configuration["WeatherbitApi:ApiKey"];
        string apiUrl = $"{_configuration["WeatherbitApi:BaseUrl"]}current?postal_code={postalCode}&key={apiKey}";

        var response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var forecast = JsonSerializer.Deserialize<WeatherForecast>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return forecast;
        }

        return null;
    }
}
