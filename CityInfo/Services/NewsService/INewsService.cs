using System;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace CityInfo.Services.NewsService
{
	public interface INewsService
	{
	  	Task<List<Article>> GetByCountry(Countries country, string apiKey);
	}
}

