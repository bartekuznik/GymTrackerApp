namespace GymTrackerAPI.Models.WaterLog
{
    public class WaterLogDto : BaseWaterLogDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset LoggedAt { get; set; }
    }
}
