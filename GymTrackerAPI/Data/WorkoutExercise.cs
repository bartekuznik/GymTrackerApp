using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Data
{
    public class WorkoutExercise
    {
        public Guid Id { get; set; }
        public Guid? ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public Guid WorkoutId { get; set; }
        public Workout Workout { get; set; }
        [Range(0, 100)]
        public short Order {  get; set; }
        public List<WorkoutSet> WorkoutSet { get; set; } = new();
    }
}
