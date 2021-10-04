using MS.MediCenter.Application.Interfaces.Security;

namespace MS.MediCenter.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}