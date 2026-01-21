using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.NutritionLog
{
    public class BaseNutritionLogDto
    {
        [Required]
        public string? FoodName { get; set; }
        [Required]
        [Range(0, 10000)]
        public decimal Calories { get; set; }
        [Range(0, 1000)]
        public decimal Protein { get; set; }
        [Range(0, 1000)]
        public decimal Carbs { get; set; }
        [Range(0, 1000)]
        public decimal Fat { get; set; }
        public DateTimeOffset ConsumedAt { get; set; }
    }
}
