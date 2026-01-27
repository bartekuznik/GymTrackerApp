using GymTrackerAPI.Data;
using GymTrackerAPI.Models.Workout;
using GymTrackerAPI.Models.WorkoutExercise;

namespace GymTrackerAPI.Contracts
{
    public interface IWorkoutExercisesRepository : IGenericsRepository<WorkoutExercise>
    {
        Task<IEnumerable<WorkoutExercise>> GetWorkoutExerciseByWorkoutIdAsync(Guid workoutId);
        Task<IEnumerable<WorkoutExerciseDto>> GetWorkoutExerciseByWorkoutIdWithPreviewAsync(Guid workoutId);
    }
}
