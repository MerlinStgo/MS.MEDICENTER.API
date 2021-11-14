using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Infrastructure.Repositories.Security;

namespace MS.MediCenter.Infrastructure.Repositories
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(UserRepository));

            #region caching
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("Caching:RedisConnection");
            });
            #endregion
        }
    }
}
