namespace GymTrackerAPI.Data
{
    public class Workout
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset? EndAt {  get; set; }    
        public string? Notes { get; set; }

        public List<WorkoutExercise> WorkoutExercise { get; set; } = new();
    } 
}
