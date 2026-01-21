using GymTrackerAPI.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.WorkoutSet
{
    public class BaseWorkoutSetDto
    {
        [Required]
        [Range(0, 100)]
        public short Order { get; set; }
        [Range(0, 1000)]
        public decimal? Weight { get; set; }
        [Range(0, 5000)]
        public short? Reps { get; set; }
        public short? RestTime { get; set; }
        [Required]
        public SetType Type { get; set; } // Warmup, Work, DropSet, Failure
        public bool IsCompleted { get; set; }
    }
}
