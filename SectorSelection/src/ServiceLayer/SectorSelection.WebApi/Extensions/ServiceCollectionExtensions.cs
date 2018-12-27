using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Entities;
using SectorSelection.Repositories.Sector;
using SectorSelection.Repositories.User;
using SectorSelection.Repositories.UserSectors;
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
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserSectorsRepository, UserSectorsRepository>();
        }
    }
}