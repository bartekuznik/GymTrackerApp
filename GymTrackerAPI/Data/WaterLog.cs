using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Data
{
    public class WaterLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTimeOffset LoggedAt { get; set; }
        [Range(0, 5000)]
        public short AmountMilliliters { get; set; }
    }
}
