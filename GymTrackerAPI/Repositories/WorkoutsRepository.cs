using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.Workout;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Repositories
{
    public class WorkoutsRepository : GenericsRepository<Workout>, IWorkoutsRepository
    {
        public WorkoutsRepository(GymTrackerDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WorkoutPreviewDto>> GetAllWorkkousWithPreviewAsync()
        {
            return await _context.Workouts
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

        public async Task<Workout?> GetWorkoutWithDetailsAsync(Guid id)
        {
            return await _context.Workouts
                .Include(w => w.WorkoutExercise)
                    .ThenInclude(e => e.WorkoutSet) 
                .AsNoTracking() 
                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
