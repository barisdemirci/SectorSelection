using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.Network;
using SectorSelection.Web.Services.Sector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SectorSelection.Core;

namespace SectorSelection.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<ISectorService, SectorService>();
        }

        public static void AddHttpClientWrapper(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddSingleton<IHttpClientWrapper>(provider => new HttpClientWrapper(configuration));

        }
    }
}