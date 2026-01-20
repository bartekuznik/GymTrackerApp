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
        }
    }
}
