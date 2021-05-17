using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tmdt.Domain.Interfaces.Base
{
    public interface IService<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangeAsync();
    }
}
