using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Application.Interfaces.Security;
using MS.MediCenter.Core.Security;

namespace MS.MediCenter.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository<User> userRepository)
        {
            Users = userRepository;
        }
        public IUserRepository<User> Users { get; }
    }
}
