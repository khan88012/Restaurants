﻿
namespace Restaurants.API.Controllers
{
    public interface IWeatherForcastService
    {
        IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTemperature);
    }
}