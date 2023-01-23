using System;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace CityInfo.Services
{
	public interface INewsService
	{
	  	Task<List<Article>> GetByCountry(Countries country, string apiKey);
	}
}

