using GymTrackerAPI.Data;

namespace GymTrackerAPI.Contracts
{
    public interface IWorkoutSetsRepository : IGenericsRepository<WorkoutSet>
    {
        Task<IEnumerable<WorkoutSet>> GetSetsByExerciseIdAsync(Guid exerciseId);
    }
}
