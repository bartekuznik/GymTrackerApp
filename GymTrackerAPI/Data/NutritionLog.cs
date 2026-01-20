namespace GymTrackerAPI.Data
{
    public class NutritionLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTimeOffset ConsumedAt { get; set; }
        public string? FoodName { get; set; }
        public decimal Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fat { get; set; }
    }
}
