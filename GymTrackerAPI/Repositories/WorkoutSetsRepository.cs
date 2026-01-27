using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Repositories
{
    public class WorkoutSetsRepository : GenericsRepository<WorkoutSet>, IWorkoutSetsRepository
    {
      
        public WorkoutSetsRepository(GymTrackerDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WorkoutSet>> GetSetsByExerciseIdAsync(Guid exerciseId)
        {
            return await _context.Set<WorkoutSet>()
                .Where(s => s.WorkoutExerciseId == exerciseId)
                .OrderBy(s => s.Order).ToListAsync();
        }
    }
}
