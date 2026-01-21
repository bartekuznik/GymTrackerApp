namespace GymTrackerAPI.Models.BodyMeasurementLog
{
    public class UpdateBodyMeasurementLogDto : BaseBodyMeasurementLogDto 
    {
        public Guid Id { get; set; }
        public decimal Weight { get; set; }
    }
}
