using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.NutritionLog
{
    public class UpdateNutritionLogDto : BaseNutritionLogDto
    {
        [Required]
        public Guid Id { get; set; }
    }
}
