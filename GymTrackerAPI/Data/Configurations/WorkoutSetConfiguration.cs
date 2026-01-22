using GymTrackerAPI.Data.Enums;
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


            //Workout Jana 
            var janEx1Id = Guid.Parse("C1111111-E111-1111-1111-111111111111");
            var janEx2Id = Guid.Parse("C1111111-E222-1111-1111-111111111111");
            //Workout Anny
            var annaEx1Id = Guid.Parse("D2222222-E111-2222-2222-222222222222");
            var annaEx2Id = Guid.Parse("D2222222-E222-2222-2222-222222222222");

            builder.HasData(
                new WorkoutSet 
                { 
                    Id = new Guid("43E759DD-91F6-4071-9FB2-DA82366D36A1"), 
                    WorkoutExerciseId = janEx1Id, 
                    Order = 1, 
                    Weight = 80.00m, 
                    Reps = 10, 
                    Type = SetType.Work, 
                    IsCompleted = true 
                },
                new WorkoutSet 
                { 
                    Id = new Guid("D665BDDF-B970-4D0A-B3D6-E8602693AC09"), 
                    WorkoutExerciseId = janEx1Id, 
                    Order = 2, Weight = 85.00m, 
                    Reps = 8, 
                    Type = SetType.Work, 
                    IsCompleted = true 
                },
                new WorkoutSet 
                { 
                    Id = new Guid("668148B6-DEF7-472F-B5DB-0B64027EB618"), 
                    WorkoutExerciseId = janEx2Id, 
                    Order = 1, 
                    Weight = 120.00m, 
                    Reps = 5, 
                    Type = SetType.Work, 
                    IsCompleted = true 
                },
                new WorkoutSet 
                { 
                    Id = new Guid("BA0021EF-D9D3-4EFC-83F0-7DF2A7134612"), 
                    WorkoutExerciseId = janEx2Id, 
                    Order = 2, 
                    Weight = 130.00m, 
                    Reps = 3, 
                    Type = SetType.Work, 
                    IsCompleted = true },
                new WorkoutSet 
                { 
                    Id = new Guid("12A6049C-262C-43F2-888F-8593DCF79E3E"), 
                    WorkoutExerciseId = annaEx1Id, 
                    Order = 1, 
                    Weight = 30.00m, 
                    Reps = 12, 
                    Type = SetType.Warmup, 
                    IsCompleted = true 
                },
                new WorkoutSet 
                { 
                    Id = new Guid("4F2811D9-5733-46B6-85B8-BEF6714841DD"), 
                    WorkoutExerciseId = annaEx1Id, 
                    Order = 2, 
                    Weight = 40.00m, 
                    Reps = 10, 
                    Type = SetType.Work, 
                    IsCompleted = true 
                },
                new WorkoutSet 
                { 
                    Id = new Guid("2FED9EB5-43D6-4207-8262-363D64242295"), 
                    WorkoutExerciseId = annaEx2Id, 
                    Order = 1, 
                    Weight = 50.00m, 
                    Reps = 10, 
                    Type = SetType.Work, 
                    IsCompleted = true 
                },
                new WorkoutSet 
                { 
                    Id = new Guid("D4EF5A40-4437-4FCB-8B72-EA994924423C"), 
                    WorkoutExerciseId = annaEx2Id, 
                    Order = 2, 
                    Weight = 55.00m, 
                    Reps = 8, 
                    Type = SetType.Work, 
                    IsCompleted = true 
                }
            );
        }
    }
}
