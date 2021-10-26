using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.MediCenter.Application.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
