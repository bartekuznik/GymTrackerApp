using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerAPI.Data.Configurations
{
    public class WaterLogConfiguration : IEntityTypeConfiguration<WaterLog>
    {
        public void Configure(EntityTypeBuilder<WaterLog> builder)
        {
            builder.ToTable("WaterLogs");

            builder.HasKey(x => x.Id); 

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.AmountMilliliters)
                .IsRequired();

            builder.Property(x => x.LoggedAt)
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.HasIndex(x => new { x.UserId, x.LoggedAt })
                .HasDatabaseName("IX_WaterLog_User_Date");// Indeks kompozytowy
        }
    }
}
