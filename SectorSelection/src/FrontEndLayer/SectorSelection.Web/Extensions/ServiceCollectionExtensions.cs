using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.Network;
using SectorSelection.Web.Services.Sector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorSelection.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IHttpClientWrapper, HttpClientWrapper>()
                .AddTransient<ISectorService, SectorService>();
        }
    }
}