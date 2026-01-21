using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.WorkoutSet
{
    public class UpdateWorkoutSetDto : BaseWorkoutSetDto
    {
        public Guid Id { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }
    }
}
