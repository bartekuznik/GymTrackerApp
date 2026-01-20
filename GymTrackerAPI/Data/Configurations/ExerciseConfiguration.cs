using GymTrackerAPI.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerAPI.Data.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(x => x.Name).IsUnique(); //Brak duplikatów

            builder.Property(x => x.Type)
                .HasConversion<string>() //Mapowanie enum na string
                .IsRequired();

            builder.Property(x => x.PrimaryMuscleGroup)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.SecondaryMuscleGroups)
                .HasConversion<string>()
               .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted); //Filtr na soft deleted



            builder.HasData(
                new Exercise
                {
                    Id = new Guid("A1111111-1111-1111-1111-111111111111"),
                    Name = "Wyciskanie sztangi na ławce poziomej",
                    Type = ExerciseType.Bodyweight,
                    PrimaryMuscleGroup = MuscleGroup.Chest,
                    SecondaryMuscleGroups = MuscleGroup.Triceps,
                    IsDeleted = false
                },
                new Exercise
                {
                    Id = new Guid("A2222222-2222-2222-2222-222222222222"),
                    Name = "Martwy ciąg",
                    Type = ExerciseType.Bodyweight,
                    PrimaryMuscleGroup = MuscleGroup.LowerBack,
                    SecondaryMuscleGroups = MuscleGroup.Hamstrings,
                    IsDeleted = false
                },
                new Exercise
                {
                    Id = new Guid("A3333333-3333-3333-3333-333333333333"),
                    Name = "Przysiady ze sztangą",
                    Type = ExerciseType.Bodyweight,
                    PrimaryMuscleGroup = MuscleGroup.Quadriceps,
                    SecondaryMuscleGroups = MuscleGroup.Glutes,
                    IsDeleted = false
                },
                new Exercise
                {
                    Id = new Guid("A4444444-4444-4444-4444-444444444444"),
                    Name = "Podciąganie na drążku",
                    Type = ExerciseType.Bodyweight,
                    PrimaryMuscleGroup = MuscleGroup.Lats,
                    SecondaryMuscleGroups = MuscleGroup.Biceps,
                    IsDeleted = false
                },
                new Exercise
                {
                    Id = new Guid("A5555555-5555-5555-5555-555555555555"),
                    Name = "Wyciskanie żołnierskie (OHP)",
                    Type = ExerciseType.Bodyweight,
                    PrimaryMuscleGroup = MuscleGroup.AnteriorDeltoid,
                    SecondaryMuscleGroups = MuscleGroup.Triceps,
                    IsDeleted = false
                }
            );
        }
    }
}
