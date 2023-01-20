using System;
using CityInfo.Models;

namespace CityInfo.Services.NewsService
{
	public interface INewsService
	{
	  	Task<IEnumerable<News>> GetByCountry(string country, string apiKey);
	}
}

