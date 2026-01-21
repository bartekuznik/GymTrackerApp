using GymTrackerAPI.Models.WorkoutExercise;

namespace GymTrackerAPI.Models.Workout
{
    public class WorkoutDto : BaseWorkoutDto
    {
        public Guid Id { get; set; }
        public List<WorkoutExerciseDto> WorkoutExerciseDto { get; set; } = new();
    }
}
