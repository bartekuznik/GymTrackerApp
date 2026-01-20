using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerAPI.Data.Configurations
{
    public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
    {
        public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
        {
            builder.ToTable("WorkoutExercises");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Exercise)
                .WithMany()
                .HasForeignKey(x => x.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ExerciseId)
                .IsRequired(false);

            builder.HasOne(e => e.Workout)
                .WithMany(w => w.WorkoutExercise)
                .HasForeignKey(w => w.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.HasMany(e => e.WorkoutSet)
                .WithOne(s => s.WorkoutExercise)
                .HasForeignKey(s => s.WorkoutExerciseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.WorkoutId, x.Order });
        }
    }
}
