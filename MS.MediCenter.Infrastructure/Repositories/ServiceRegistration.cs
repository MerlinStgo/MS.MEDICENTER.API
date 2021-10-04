using Microsoft.Extensions.DependencyInjection;
using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Application.Interfaces.Security;
using MS.MediCenter.Infrastructure.Repositories.Security;

namespace MS.MediCenter.Infrastructure.Repositories
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
