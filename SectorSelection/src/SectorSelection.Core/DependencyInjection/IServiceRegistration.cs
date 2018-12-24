using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Core.DependencyInjection
{
    public interface IServiceRegistration
    {
        void Register(IServiceCollection services);
    }
}