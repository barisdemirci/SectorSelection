using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.DependencyInjection;
using SectorSelection.Repositories.Sector;
using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Repositories
{
    public sealed class RepositoriesRegistration : IServiceRegistration
    {
        private readonly IServiceRegistration[] serviceRegistrations =
        {
            new SectorRepositoriesRegistration()
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