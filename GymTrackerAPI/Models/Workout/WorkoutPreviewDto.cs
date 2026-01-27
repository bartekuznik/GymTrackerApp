namespace GymTrackerAPI.Models.Workout
{
    public class WorkoutPreviewDto : BaseWorkoutDto
    {
        public Guid Id { get; set; }
        public List<string> WorkoutExerciseDto { get; set; } = new();
    }
}
