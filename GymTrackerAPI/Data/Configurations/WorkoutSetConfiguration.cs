using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerAPI.Data.Configurations
{
    public class WorkoutSetConfiguration : IEntityTypeConfiguration<WorkoutSet>
    {
        public void Configure(EntityTypeBuilder<WorkoutSet> builder)
        {
            builder.ToTable("WorkoutSets");

            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.WorkoutExercise)
                .WithMany(e => e.WorkoutSet)
                .HasForeignKey(s => s.WorkoutExerciseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.Property(x => x.Weight)
                .HasPrecision(5, 2)
                .IsRequired(false);

            builder.Property(x => x.Reps)
                .IsRequired(false);

            builder.Property(x => x.RestTime)
                .IsRequired(false);

            builder.Property(x => x.Type)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.RowVersion)
                .IsRowVersion();

            builder.Property(x => x.IsCompleted)
                .HasDefaultValue(false);

            builder.HasIndex(x => new { x.WorkoutExerciseId, x.Order })
                .HasDatabaseName("IX_WorkoutSet_ExerciseId_Order"); ;
        }
    }
}
