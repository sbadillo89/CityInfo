using System;
using System.Net.Http;
using CityInfo.Models;
using Newtonsoft.Json;

namespace CityInfo.Services.NewsService
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("NewsApi");
        }

        public async Task<IEnumerable<News>> GetByCountry(string countryCode, string apiKey)
        {
            var requestUri = $"top-headlines?country={countryCode}&apiKey={apiKey}";

            var requestMsg = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMsg.Headers.Add("Authorization", apiKey);
            var response = await _httpClient.SendAsync(requestMsg);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<News>>();

            return null;

        }
    }
}
//https://newsapi.org/v2/top-headlines?country=co&apiKey=10dc710ef5d740f590a8c7fe3b8a0604
//https://newsapi.org/v2/top-headlines?country=co&apiKey=10dc710ef5d740f590a8c7fe3b8a0604
