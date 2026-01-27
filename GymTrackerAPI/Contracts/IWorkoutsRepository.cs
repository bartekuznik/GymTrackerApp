using GymTrackerAPI.Data;
using GymTrackerAPI.Models.Workout;

namespace GymTrackerAPI.Contracts
{
    public interface IWorkoutsRepository : IGenericsRepository<Workout>
    {
        Task<IEnumerable<WorkoutPreviewDto>> GetAllWorkkousWithPreviewAsync();
        Task<Workout> GetWorkoutWithDetailsAsync(Guid id);
    }
}
