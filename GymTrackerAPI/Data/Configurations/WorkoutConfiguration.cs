using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerAPI.Data.Configurations
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable("Workouts");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.StartAt)
                .IsRequired();

            builder.Property(x => x.EndAt)
                .IsRequired(false);

            builder.Property(x => x.Name)
                .HasMaxLength(5000)
                .IsRequired(false);

            builder.HasMany(w => w.WorkoutExercise)
                .WithOne(e =>  e.Workout)
                .HasForeignKey(e => e.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.UserId, x.StartAt })
            .HasDatabaseName("IX_Workout_UserId_StartAt");
        }
    }
}
