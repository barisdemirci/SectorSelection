using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Repositories.Sector
{
    public sealed class SectorRepositoriesRegistration : IServiceRegistration
    {
        public void Register(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<ISectorRepository, SectorRepository>();
        }
    }
}