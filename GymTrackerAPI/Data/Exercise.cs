using GymTrackerAPI.Data.Enums;

namespace GymTrackerAPI.Data
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ExerciseType Type { get; set; }
        public MuscleGroup PrimaryMuscleGroup { get; set; }
        public MuscleGroup SecondaryMuscleGroups { get; set; }
        public bool IsDeleted { get; set; } // Soft delete, aby nie psuć historycznych treningów
    }
}
