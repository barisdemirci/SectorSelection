using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Core.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceRegistrations(this IServiceCollection services, params IServiceRegistration[] registrations)
        {
            foreach (IServiceRegistration registration in registrations)
            {
                registration.Register(services);
            }
        }

        public static void AddServiceRegistrations(this IServiceCollection services, IEnumerable<IServiceRegistration> registrations)
        {
            foreach (IServiceRegistration registration in registrations)
            {
                registration.Register(services);
            }
        }
    }
}