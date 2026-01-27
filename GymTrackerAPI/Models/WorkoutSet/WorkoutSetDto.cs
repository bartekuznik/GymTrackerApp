namespace GymTrackerAPI.Models.WorkoutSet
{
    public class WorkoutSetDto : BaseWorkoutSetDto
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
