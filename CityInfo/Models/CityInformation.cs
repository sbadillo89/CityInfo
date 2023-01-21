using System;
using NewsAPI.Models;

namespace CityInfo.Models
{
	public class CityInformation
	{
		public CityInformation()
		{

		}

		public string Name { get; set; }
		public List<Article> News { get; set; }
		public CurrentWeather CurrentWeather { get; set; }
	}
}	

