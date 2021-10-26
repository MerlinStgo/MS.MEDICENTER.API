using Microsoft.Extensions.DependencyInjection;
using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Infrastructure.Repositories.Security;

namespace MS.MediCenter.Infrastructure.Repositories
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(UserRepository<>));
        }
    }
}
