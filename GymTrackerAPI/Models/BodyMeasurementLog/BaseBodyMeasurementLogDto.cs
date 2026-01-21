using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.BodyMeasurementLog
{
    public abstract class BaseBodyMeasurementLogDto
    {
        [Required]
        [Range(20, 500, ErrorMessage = "Waga musi być między 20 a 500 kg")]
        public decimal Weight { get; set; }
    }
}


//w controllerach dodam temporary usera -> potem zastapic jwt