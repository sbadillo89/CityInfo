using System;
namespace CityInfo.Models
{
    public class ExternalApiSettings
    {
        public Settings NewsApi { get; set; }
        public Settings OpenWeather { get; set; }
    }

    public class Settings
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
    }   
}

