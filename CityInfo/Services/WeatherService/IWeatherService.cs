using System;
using CityInfo.Models;

namespace CityInfo.Services.WeatherService
{
	public interface IWeatherService
	{
		Task<CurrentWeather> GetByCountry(string country, string apiKey);
	}
}

