using MS.MediCenter.Core.Security;

namespace MS.MediCenter.Application.Interfaces.Security
{
    public interface IUserRepository<T> : IRepositoryAsync<T> where T : class
    {
    }
}
