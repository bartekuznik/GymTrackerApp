using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Repositories
{
    public class GenericsRepository<T> : IGenericsRepository<T> where T : class
    {
        protected readonly GymTrackerDbContext _context;

        public GenericsRepository(GymTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            if (id == Guid.Empty) 
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);

        }

        public async Task<bool> Exists(Guid id)
        {

            var entity = await GetById(id);
            if (entity == null) { 
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return false; // Nie znaleźliśmy, więc nie usuniemy
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true; // Udało się usunąć
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
