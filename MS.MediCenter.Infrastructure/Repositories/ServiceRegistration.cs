using Microsoft.Extensions.DependencyInjection;

namespace MS.MediCenter.Infrastructure.Repositories
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            //services.AddTransient<IUserRepository<User>, UserRepository>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
