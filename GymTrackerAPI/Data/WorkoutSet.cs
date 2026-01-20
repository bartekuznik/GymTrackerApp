using GymTrackerAPI.Data.Enums;
using Microsoft.Build.Utilities;
using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Data
{
    public class WorkoutSet
    {
        public Guid Id { get; set; }
        public Guid WorkoutExerciseId { get; set; }
        public WorkoutExercise WorkoutExercise { get; set; }
        [Range(0, 100)]
        public short Order { get; set; }
        [Range(0, 1000)]
        public decimal? Weight { get; set; }
        [Range(0, 5000)]
        public short? Reps { get; set; }
        public short? RestTime { get; set; }
        public SetType Type { get; set; } // Warmup, Work, DropSet, Failure
        public bool IsCompleted { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } //Concurrency Token
    }
}
