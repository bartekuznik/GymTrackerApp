using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.WorkoutExercise;
using GymTrackerAPI.Models.WorkoutSet;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Repositories
{
    public class WorkoutExercisesRepository : GenericsRepository<WorkoutExercise>, IWorkoutExercisesRepository
    {
        public WorkoutExercisesRepository(GymTrackerDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WorkoutExercise>> GetWorkoutExerciseByWorkoutIdAsync(Guid workoutId, Guid userId)
        {
            return await _context.Set<WorkoutExercise>()
               .Where(s => s.WorkoutId == workoutId && s.Workout.UserId == userId)
               .OrderBy(s => s.Order).ToListAsync();
        }

        public async Task<IEnumerable<WorkoutExerciseDto>> GetWorkoutExerciseByWorkoutIdWithPreviewAsync(Guid workoutId, Guid userId)
        {
            return  await _context.Set<WorkoutExercise>()
                .Where(s => s.WorkoutId == workoutId && s.Workout.UserId == userId)
                .OrderBy(s => s.Order)
                .Select(w => new WorkoutExerciseDto
                    {
                        Id = w.Id,
                        Order = w.Order,
                        WorkoutSet = w.WorkoutSet.Select(set => new WorkoutSetDto
                            {
                                Id = set.Id,
                                Weight = set.Weight,
                                Reps = set.Reps
                            }).ToList()
                    }).ToListAsync();
        }
    }
}
