using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.DependencyInjection;
using SectorSelection.Repositories.Sector;
using SectorSelection.Repositories.User;
using SectorSelection.Repositories.UserSectors;

namespace SectorSelection.Repositories
{
    public sealed class RepositoriesRegistration : IServiceRegistration
    {
        private readonly IServiceRegistration[] serviceRegistrations =
        {
            new SectorRepositoriesRegistration(),
            new UserRepositoriesRegistration(),
            new UserSectorsRepositoriesRegistration()
        };

        public void Register(IServiceCollection services)
        {
            foreach (IServiceRegistration registration in serviceRegistrations)
            {
                registration.Register(services);
            }
        }
    }
}