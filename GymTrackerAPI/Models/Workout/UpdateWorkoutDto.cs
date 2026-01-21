using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.Workout
{
    public class UpdateWorkoutDto : BaseWorkoutDto
    {
        [Required]
        public Guid Id { get; set; }
    }
}
