using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.Network;
using SectorSelection.Web.Services.Sector;
using SectorSelection.Web.Services.UserSectors;

namespace SectorSelection.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<ISectorService, SectorService>()
                .AddTransient<IUserSectorsService, UserSectorsService>();
        }

        public static void AddHttpClientWrapper(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddSingleton<IHttpClientWrapper>(provider => new HttpClientWrapper(configuration));

        }
    }
}