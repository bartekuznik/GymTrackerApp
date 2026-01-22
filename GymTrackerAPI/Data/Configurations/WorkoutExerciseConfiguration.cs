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

            //Jan Workout 
            var janWorkoutId = Guid.Parse("C1111111-1111-1111-1111-111111111111");
            var janEx1Id = Guid.Parse("C1111111-E111-1111-1111-111111111111");
            var janEx2Id = Guid.Parse("C1111111-E222-1111-1111-111111111111");
            //Anna Workout 
            var annaWorkoutId = Guid.Parse("D2222222-2222-2222-2222-222222222222");
            var annaEx1Id = Guid.Parse("D2222222-E111-2222-2222-222222222222");
            var annaEx2Id = Guid.Parse("D2222222-E222-2222-2222-222222222222");

            builder.HasData(
                new WorkoutExercise 
                { 
                    Id = janEx1Id, 
                    WorkoutId = janWorkoutId, 
                    ExerciseId = new Guid("A1111111-1111-1111-1111-111111111111"), 
                    Order = 1 
                },
                new WorkoutExercise 
                { 
                    Id = janEx2Id, 
                    WorkoutId = janWorkoutId, 
                    ExerciseId = new Guid("A2222222-2222-2222-2222-222222222222"), 
                    Order = 2 
                },
                new WorkoutExercise 
                { 
                    Id = annaEx1Id, 
                    WorkoutId = annaWorkoutId, 
                    ExerciseId = new Guid("A1111111-1111-1111-1111-111111111111"), 
                    Order = 1 
                },
                new WorkoutExercise 
                { 
                    Id = annaEx2Id, 
                    WorkoutId = annaWorkoutId, 
                    ExerciseId = new Guid("A2222222-2222-2222-2222-222222222222"), 
                    Order = 2 
                }

            );
        }
    }
}
