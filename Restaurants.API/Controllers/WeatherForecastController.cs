using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
   

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForcastService _weatherForcastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger , 
        IWeatherForcastService weatherForcast)
    {
        _logger = logger;
        _weatherForcastService = weatherForcast;
    }

    [HttpGet]
    [Route("Example")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _weatherForcastService.Get();
    }
}
