using GymTrackerAPI.Data;

namespace GymTrackerAPI.Contracts
{
    public interface IGenericsRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        Task<T> AddAsync(T entity);
        Task<bool> Exists(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}
