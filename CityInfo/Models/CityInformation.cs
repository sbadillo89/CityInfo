using System;
namespace CityInfo.Models
{
	public class CityInformation
	{
		public CityInformation()
		{

		}

		public string Name { get; set; }
		public List<News> News { get; set; }
		public Weather CurrentWeather { get; set; }
	}
}	

