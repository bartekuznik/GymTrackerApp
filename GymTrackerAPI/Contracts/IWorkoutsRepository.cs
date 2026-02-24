using GymTrackerAPI.Data;
using GymTrackerAPI.Models.Workout;
using System.Linq.Expressions;

namespace GymTrackerAPI.Contracts
{
    public interface IWorkoutsRepository : IGenericsRepository<Workout>
    {
        Task<IEnumerable<WorkoutPreviewDto>> GetAllWorkkousWithPreviewAsync(Guid userId);
        Task<Workout> GetWorkoutWithDetailsAsync(Guid id, Guid userId);
    }
}
