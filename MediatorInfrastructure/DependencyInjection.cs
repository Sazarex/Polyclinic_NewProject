using Interfaces.ServiceLayers;
using Interfaces.ServiceLayersInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediatorInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterMediatorInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IPasswordService, PasswordServiceLayer>();
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.Load("MediatorInfrastructure")));
            return services;
        }
    }
}
