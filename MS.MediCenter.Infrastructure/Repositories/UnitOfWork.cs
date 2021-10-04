using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Application.Interfaces.Security;

namespace MS.MediCenter.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository)
        {
            Users = userRepository;
        }
        public IUserRepository Users { get; }
    }
}
