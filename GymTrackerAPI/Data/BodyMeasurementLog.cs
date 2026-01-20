namespace GymTrackerAPI.Data
{
    public class BodyMeasurementLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal Weight { get; set; }
        public DateTimeOffset LoggedAt { get; set; }
    }
}
