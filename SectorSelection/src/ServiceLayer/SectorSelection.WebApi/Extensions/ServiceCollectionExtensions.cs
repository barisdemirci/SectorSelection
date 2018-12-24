using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.DependencyInjection;
using SectorSelection.Entities;
using SectorSelection.Repositories;
using SectorSelection.Repositories.Sector;
using SectorSelection.Services;
using SectorSelection.Services.Sector;

namespace SectorSelection.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddTransient<ISectorService, SectorService>();
            services.AddTransient<ISectorRepository, SectorRepository>();
        }
    }
}