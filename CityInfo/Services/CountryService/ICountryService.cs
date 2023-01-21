using System;
using CityInfo.Models;

namespace CityInfo.Services.CountryService
{
	public interface ICountryService
	{
		Task<CountryInformation> GetAllCountries();
	}
}

