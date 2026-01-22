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


            var user1Id = Guid.Parse("42A01733-E4B8-46C0-95C0-CD178CA92D1C"); // Jan
            var user2Id = Guid.Parse("C63780C7-30DF-4829-89A8-27B34463452A"); // Anna

            var janWorkoutId = Guid.Parse("C1111111-1111-1111-1111-111111111111");
            var annaWorkoutId = Guid.Parse("D2222222-2222-2222-2222-222222222222");

            builder.HasData(new Workout
            {
                Id = janWorkoutId,
                UserId = user1Id,
                Name = "Siła - Klatka i Plecy",
                StartAt = new DateTimeOffset(2023, 11, 04, 17, 0, 0, TimeSpan.Zero),
                EndAt = new DateTimeOffset(2023, 11, 04, 18, 15, 0, TimeSpan.Zero),
                Notes = "Bardzo dobra sesja, progres w martwym ciągu."
            },
            new Workout
            {
                Id = annaWorkoutId,
                UserId = user2Id,
                Name = "FBW - Start",
                StartAt = new DateTimeOffset(2023, 11, 04, 09, 30, 0, TimeSpan.Zero),
                EndAt = new DateTimeOffset(2023, 11, 04, 10, 30, 0, TimeSpan.Zero),
                Notes = "Skupienie na technice."
            });
        }
    }
}
