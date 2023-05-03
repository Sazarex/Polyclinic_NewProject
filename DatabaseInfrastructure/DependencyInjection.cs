using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DatabaseInfrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DatabaseInfrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Подключение ДБ контекстов
        /// </summary>
        public static IServiceCollection RegisterDatabaseInfrastructure(this IServiceCollection services,
                                                                        IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<CommandDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}
