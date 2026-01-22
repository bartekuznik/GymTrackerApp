using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerAPI.Data.Configurations
{
    public class NutritionLogConfiguration : IEntityTypeConfiguration<NutritionLog>
    {
        public void Configure(EntityTypeBuilder<NutritionLog> builder)
        {
            builder.ToTable("NutritionLogs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ConsumedAt)
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.Property(x => x.FoodName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Calories)
                .HasPrecision(6,1)
                .IsRequired();

            builder.Property(x => x.Protein)
                .HasPrecision(4,1)
                .HasDefaultValue(0);

            builder.Property(x => x.Carbs)
                .HasPrecision(4,1)
                .HasDefaultValue(0);

            builder.Property(x => x.Fat)
                .HasPrecision(4,1)
                .HasDefaultValue(0);

            builder.HasIndex(x => new { x.UserId, x.ConsumedAt })
               .HasDatabaseName("IX_NutritionLog_User_Date");// Indeks kompozytowy

            var user1Id = Guid.Parse("42A01733-E4B8-46C0-95C0-CD178CA92D1C"); // Jan
            var user2Id = Guid.Parse("C63780C7-30DF-4829-89A8-27B34463452A"); // Anna

            builder.HasData(
                new NutritionLog
                {
                    Id = new Guid("D0C29FA2-8E25-40F9-944E-BE4CAE271E34"),
                    UserId = user1Id,
                    FoodName = "Owsianka z borówkami",
                    Calories = 450.5m,
                    Protein = 15.0m,
                    Carbs = 65.2m,
                    Fat = 12.5m,
                    ConsumedAt = new DateTimeOffset(2023, 11, 02, 8, 30, 0, TimeSpan.Zero)
                },
                new NutritionLog
                {
                    Id = new Guid("CDE21408-1258-4019-B148-C40EE67CEBDF"),
                    UserId = user1Id,
                    FoodName = "Kurczak z ryżem i brokułami",
                    Calories = 620.0m,
                    Protein = 45.5m,
                    Carbs = 70.0m,
                    Fat = 10.2m,
                    ConsumedAt = new DateTimeOffset(2023, 11, 02, 14, 00, 0, TimeSpan.Zero)
                },
                new NutritionLog
                {
                    Id = new Guid("7995FE93-1A63-417D-A347-FC7C1AAE62AF"),
                    UserId = user1Id,
                    FoodName = "Shake proteinowy",
                    Calories = 210.0m,
                    Protein = 30.0m,
                    Carbs = 5.0m,
                    Fat = 3.2m,
                    ConsumedAt = new DateTimeOffset(2023, 11, 02, 17, 30, 0, TimeSpan.Zero)
                },
                new NutritionLog
                {
                    Id = new Guid("E6646985-FD2F-4E16-B68A-3B50D55D9CF1"),
                    UserId = user2Id,
                    FoodName = "Sałatka Cezar",
                    Calories = 540.0m,
                    Protein = 28.0m,
                    Carbs = 15.5m,
                    Fat = 38.0m,
                    ConsumedAt = new DateTimeOffset(2023, 11, 02, 13, 15, 0, TimeSpan.Zero)
                },
                new NutritionLog
                {
                    Id = new Guid("2EDAF838-FB7E-42BE-99B5-E2EEB577AD3A"),
                    UserId = user2Id,
                    FoodName = "Jogurt Grecki z orzechami",
                    Calories = 320.0m,
                    Protein = 18.2m,
                    Carbs = 12.0m,
                    Fat = 22.5m,
                    ConsumedAt = new DateTimeOffset(2023, 11, 02, 20, 45, 0, TimeSpan.Zero)
                }
            );
        }
    }
}
