using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.WorkoutExercise
{
    public class BaseWorkoutExerciseDto
    {
        [Range(0, 100)]
        public short Order { get; set; }
        public Guid? ExerciseId { get; set; }
    }
}
