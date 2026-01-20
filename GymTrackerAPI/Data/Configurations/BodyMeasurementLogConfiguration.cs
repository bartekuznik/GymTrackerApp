using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerAPI.Data.Configurations
{
    public class BodyMeasurementLogConfiguration : IEntityTypeConfiguration<BodyMeasurementLog>
    {
        public void Configure(EntityTypeBuilder<BodyMeasurementLog> builder)
        {
            builder.ToTable("BodyMeasurementLogs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Weight)
                .HasPrecision(5,2)
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.LoggedAt)
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.HasIndex(x => new { x.UserId, x.LoggedAt })
                .HasDatabaseName("IX_BodyMeasurementLog_User_Date");// Indeks kompozytowy
        }
    }
}
