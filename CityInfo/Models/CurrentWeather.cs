using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace CityInfo.Models
{
    public class CurrentWeather
    {
        public CurrentWeather()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }

        public int TimeZone { get; set; }

        public string Error { get; set; }

        public Coord Coord { get; set; }

        public List<Weather> Weather { get; set; }

        public Main Main { get; set; }

        public Wind Wind { get; set; }
    }

    public class Coord
    {
        public double Lon { get; set; }

        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }

        public string Main { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }

        public double Feels_like { get; set; }

        public double Temp_Min { get; set; }

        public double Temp_Max { get; set; }

        public double Pressure { get; set; }

        public double Humidity { get; set; }

        public double Sea_Level { get; set; }

        public double Grnd_Level { get; set; }

    }

    public class Wind
    {
        public double Speed { get; set; }

        public double Deg { get; set; }

        public double Gust { get; set; }
    }
}