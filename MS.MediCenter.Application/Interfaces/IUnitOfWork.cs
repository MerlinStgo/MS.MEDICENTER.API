using MS.MediCenter.Application.Interfaces.Security;
using MS.MediCenter.Core.Security;

namespace MS.MediCenter.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository<User> Users { get; }
    }
}