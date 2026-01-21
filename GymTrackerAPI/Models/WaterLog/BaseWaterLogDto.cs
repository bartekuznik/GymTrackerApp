using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.WaterLog
{
    public class BaseWaterLogDto
    {
        [Required]
        [Range(0, 5000)]
        public short AmountMilliliters { get; set; }
    }
}
