using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
   

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherForcastService _weatherForcastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger , 
        WeatherForcastService weatherForcast)
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
