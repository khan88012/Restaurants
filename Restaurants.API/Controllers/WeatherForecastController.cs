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

 

    [HttpPost] //[HttpPost("generate")]
    [Route("generate")]
    public IActionResult Generate([FromQuery] int count , [FromBody] TemperatureRequest request)
    {
        if(count < 0 || request.Max < request.Min )
        {
            return BadRequest("Count has to be positive number, and max must be greater than the min value.");
        }
        var result = _weatherForcastService.Get(count, request.Min, request.Max);
            return Ok(result);
    }
}
