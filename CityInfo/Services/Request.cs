using System;
using Newtonsoft.Json;

namespace CityInfo.Services
{
    public class Request<T> where T : class
    {
        private readonly HttpClient _httpClient;

        public Request()
        {

        }

        public Request(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<T>> GetAllAsync(string requestUri, string token)
        {
            var requestMsg = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMsg.Headers.Add("Authorization", "Bearer " + token);
            var response = await _httpClient.SendAsync(requestMsg);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T[]>();

            return null;
        }

        public async Task<T> GetByIdAsync(string requestUri, string token)
        {
            var requestMsg = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMsg.Headers.Add("Authorization", "Bearer " + token);
            var response = await _httpClient.SendAsync(requestMsg);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();

            return null;

        }

        public async Task<T> PostAsync(string requestUri, T requestData, string token)
        {
            string serializedCategory = JsonConvert.SerializeObject(requestData);
            var requestMsg = new HttpRequestMessage(HttpMethod.Post, requestUri);
            requestMsg.Headers.Add("Authorization", "Bearer " + token);
            requestMsg.Content = new StringContent(serializedCategory);
            requestMsg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(requestMsg);
            //var response = await _httpClient.SendAsync(requestMsg, CancellationToken.None).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();

            return null;
        }

        public async Task<T> PutAsync(string requestUri, T requestData, string token)
        {
            try
            {
                string serializedCategory = JsonConvert.SerializeObject(requestData);

                var requestMsg = new HttpRequestMessage(HttpMethod.Put, requestUri);
                requestMsg.Headers.Add("Authorization", "Bearer " + token);
                requestMsg.Content = new StringContent(serializedCategory);
                requestMsg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await _httpClient.SendAsync(requestMsg);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<T>();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

