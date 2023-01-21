using Newtonsoft.Json;

namespace CityInfo.Models
{
    public class CountryInformation
	{
		public CountryInformation()
		{
		}

        public bool Error { get; set; }

        public string Message { get; set; }

        public List<Country> Data { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }

        public string Iso2 { get; set; }
    }
}

