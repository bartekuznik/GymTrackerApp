using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.Workout
{
    public class BaseWorkoutDto
    {
        [Required]
        [StringLength(200)]
        public string? Name { get; set; }
        [Required]
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset? EndAt { get; set; }
        public string? Notes { get; set; }
    }
}
