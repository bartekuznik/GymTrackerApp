using GymTrackerAPI.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.Exercise
{
    public abstract class BaseExerciseDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public ExerciseType Type { get; set; }
        [Required]
        public MuscleGroup PrimaryMuscleGroup { get; set; }
        [Required]
        public MuscleGroup SecondaryMuscleGroups { get; set; }
    }
}
