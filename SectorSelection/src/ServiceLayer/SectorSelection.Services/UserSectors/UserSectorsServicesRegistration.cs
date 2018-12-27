using System;
using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.DependencyInjection;

namespace SectorSelection.Services.UserSectors
{
    public class UserSectorsServicesRegistration : IServiceRegistration
    {
        public void Register(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IUserSectorsService, UserSectorsService>();
        }
    }
}
