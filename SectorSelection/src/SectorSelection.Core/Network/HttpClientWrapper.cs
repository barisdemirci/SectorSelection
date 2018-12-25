using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SectorSelection.Core.Network
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly IConfiguration configuration;

        public HttpClientWrapper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<bool> DeleteAsync(string endpoint)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync<TDto>(string endpoint, TDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<TDto> GetAsync<TDto>(string endpoint)
        {
            endpoint = string.Concat(this.configuration[Constants.ApiBaseUrl], endpoint);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(endpoint);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(endpoint);
            // Parse the response body.
            var dataObjects = await response.Content.ReadAsStringAsync();
            client.Dispose();
            return JsonConvert.DeserializeObject<TDto>(dataObjects);
        }

        public Task<TDto> PostAsync<TDto>(string endpoint, TDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<TResponseDto> PostAsync<TResponseDto>(string endpoint)
        {
            throw new NotImplementedException();
        }

        public Task<TResponseDto> PostAsync<TRequestDto, TResponseDto>(string endpoint, TRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task PostAsync(string endpoint)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> PutAsync<TDto>(string endpoint, TDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest dto)
        {
            throw new NotImplementedException();
        }
    }
}
