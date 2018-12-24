using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.DependencyInjection;
using SectorSelection.Services.Sector;
using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Services
{
    public class ServicesRegistration : IServiceRegistration
    {
        private readonly IServiceRegistration[] serviceRegistrations =
        {
            new SectorServicesRegistration(),
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