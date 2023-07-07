using Interfaces.ServiceLayers;
using Interfaces.ServiceLayersInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediatorInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterMediatorInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationService, AuthorizationServiceLayer>();
            services.AddScoped<IPasswordService, PasswordServiceLayer>();
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.Load("MediatorInfrastructure")));
            return services;
        }
    }
}
