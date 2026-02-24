using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.Workout;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace GymTrackerAPI.Repositories
{
    public class WorkoutsRepository : GenericsRepository<Workout>, IWorkoutsRepository
    {
        public WorkoutsRepository(GymTrackerDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WorkoutPreviewDto>> GetAllWorkkousWithPreviewAsync(Guid userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId)
                .OrderByDescending(w => w.StartAt)
                .Select(w => new WorkoutPreviewDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    StartAt = w.StartAt,
                    EndAt = w.EndAt,
                    Notes = w.Notes,
                    WorkoutExerciseDto = w.WorkoutExercise
                                  .Select(we => we.Exercise.Name)
                                  .ToList()
                }).ToListAsync();

        }

        public async Task<Workout?> GetWorkoutWithDetailsAsync(Guid id, Guid userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId)
                .Include(w => w.WorkoutExercise)
                    .ThenInclude(e => e.WorkoutSet) 
                .AsNoTracking() 
                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
