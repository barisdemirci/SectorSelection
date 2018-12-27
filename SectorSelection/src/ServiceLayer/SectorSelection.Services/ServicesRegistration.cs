using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.DependencyInjection;
using SectorSelection.Services.Sector;
using SectorSelection.Services.UserSectors;

namespace SectorSelection.Services
{
    public class ServicesRegistration : IServiceRegistration
    {
        private readonly IServiceRegistration[] serviceRegistrations =
        {
            new SectorServicesRegistration(),
            new UserSectorsServicesRegistration()
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