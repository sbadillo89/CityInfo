using System;
using CityInfo.Models;

namespace CityInfo.Services
{
	public interface ICountryService
	{
		Task<CountryInformation> GetAllCountries();
	}
}

