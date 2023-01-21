using System;
using System.Net.Http;
using CityInfo.Models;
using Newtonsoft.Json;

using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Collections.Generic;

namespace CityInfo.Services.NewsService
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("NewsApi");
        }

        public async Task<List<Article>> GetByCountry(Countries countryCode, string apiKey)
        {
            try
            {
                var newsApiClient = new NewsApiClient(apiKey);

                var response = await newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
                {
                    Country = countryCode
                });

                if (response.Status != Statuses.Ok)
                    return null;

                return response.Articles;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Article>> HttpGetByCountry(string countryCode, string apiKey)
        {
            var requestUri = $"top-headlines?country={countryCode}";

            var requestMsg = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMsg.Headers.Add("Authorization", apiKey);
            //_httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);
            var response = await _httpClient.SendAsync(requestMsg);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Article>>();

            return null;

        }
    }
}
