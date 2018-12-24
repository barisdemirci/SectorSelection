using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SectorSelection.Core.Network
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public Task<bool> DeleteAsync(string endpoint)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync<TDto>(string endpoint, TDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> GetAsync<TDto>(string endpoint)
        {
            throw new NotImplementedException();
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
