using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.DependencyInjection;
using System;

namespace SectorSelection.Repositories.UserSectors
{
    public class UserSectorsRepositoriesRegistration : IServiceRegistration
    {
        public void Register(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IUserSectorsRepository, UserSectorsRepository>();
        }
    }
}