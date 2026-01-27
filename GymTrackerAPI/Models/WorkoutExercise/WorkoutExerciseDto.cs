using GymTrackerAPI.Models.WorkoutSet;

namespace GymTrackerAPI.Models.WorkoutExercise
{
    public class WorkoutExerciseDto : BaseWorkoutExerciseDto
    {
        public Guid Id { get; set; }
        public List<WorkoutSetDto> WorkoutSet { get; set; } = new();
    }
}
