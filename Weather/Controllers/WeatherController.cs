using Microsoft.AspNetCore.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherbitService _weatherbitService;

        public WeatherController(WeatherbitService weatherbitService)
        {
            _weatherbitService = weatherbitService;
        }

        [HttpGet("GetForecast")]
        public async Task<ActionResult<WeatherForecast>> GetForecast(string postalCode)
        {
            var forecast = await _weatherbitService.GetWeatherForecastByPostalCode(postalCode);

            if (forecast != null)
            {
                return Ok(forecast);
            }
            else
            {
                return NotFound();
            }
        }
    }
}