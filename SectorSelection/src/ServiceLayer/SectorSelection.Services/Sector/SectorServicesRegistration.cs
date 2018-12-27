using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.DependencyInjection;
using SectorSelection.Services.UserSectors;
using System;
namespace SectorSelection.Services.Sector
{
    public class SectorServicesRegistration : IServiceRegistration
    {
        public void Register(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<ISectorService, SectorService>();
        }
    }
}