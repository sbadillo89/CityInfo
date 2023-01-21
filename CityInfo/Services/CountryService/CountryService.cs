using System;
using System.Net.Http;
using CityInfo.Models;
using NewsAPI.Models;

namespace CityInfo.Services.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<CountryInformation> GetAllCountries()
        {
            try
            {
                var requestUri = "https://countriesnow.space/api/v0.1/countries/iso";

                var requestMsg = new HttpRequestMessage(HttpMethod.Get, requestUri);
                var response = await _httpClient.SendAsync(requestMsg);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<CountryInformation>();

            }
            catch (Exception ex)
            {
                return new CountryInformation { Error = true, Message = ex.Message };
            }

            return null;
        }
    }
}

