using System;
using CityInfo.Models;

namespace CityInfo.Services
{
	public interface IWeatherService
	{
		Task<CurrentWeather> GetByCountry(string country, string apiKey);
	}
}

