namespace GymTrackerAPI.Models.BodyMeasurementLog
{
    public class BodyMeasurementLogDto : BaseBodyMeasurementLogDto 
    {
        public Guid Id { get; set; }
        public DateTimeOffset LoggedAt { get; set; }
    }
}
