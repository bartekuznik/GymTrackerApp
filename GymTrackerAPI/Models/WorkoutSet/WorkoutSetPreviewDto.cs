using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.WorkoutSet
{
    public class WorkoutSetPreviewDto
    {
        public decimal? Weight { get; set; }
        [Range(0, 5000)]
        public short? Reps { get; set; }
    }
}
