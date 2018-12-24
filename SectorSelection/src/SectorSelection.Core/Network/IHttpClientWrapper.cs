using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SectorSelection.Core.Network
{
    public interface IHttpClientWrapper
    {
        Task<TDto> PostAsync<TDto>(string endpoint, TDto dto);

        Task<TResponseDto> PostAsync<TResponseDto>(string endpoint);

        Task<TResponseDto> PostAsync<TRequestDto, TResponseDto>(string endpoint, TRequestDto dto);

        Task PostAsync(string endpoint);

        Task<TDto> GetAsync<TDto>(string endpoint);

        Task<TDto> PutAsync<TDto>(string endpoint, TDto dto);

        Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest dto);

        Task<bool> DeleteAsync(string endpoint);

        Task<bool> DeleteAsync<TDto>(string endpoint, TDto dto);
    }
}