using GymTrackerAPI.Data;
using System.Linq.Expressions;

namespace GymTrackerAPI.Contracts
{
    public interface IGenericsRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetById(Guid id, Expression<Func<T, bool>> filter = null);
        Task<T> AddAsync(T entity);
        Task<bool> Exists(Guid id);
        Task<bool> DeleteAsync(Guid id, Expression<Func<T, bool>> filter = null);
        Task UpdateAsync(T entity);
    }
}
