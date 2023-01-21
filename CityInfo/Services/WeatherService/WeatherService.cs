using System;
using System.Net.Http;
using CityInfo.Models;
using Microsoft.AspNetCore.Http;
using NewsAPI.Models;
using Newtonsoft.Json;

namespace CityInfo.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OpenWeather");
        }

        public async Task<CurrentWeather> GetByCountry(string country, string apiKey)
        {
            try
            {
                var requestUri = $"weather?q={country}&appid={apiKey}";

                var requestMsg = new HttpRequestMessage(HttpMethod.Get, requestUri);
                var response = await _httpClient.SendAsync(requestMsg);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<CurrentWeather>();

            }
            catch (Exception ex)
            {
                return new CurrentWeather { Error = ex.Message };
            }

            return null;
        }
    }
}

