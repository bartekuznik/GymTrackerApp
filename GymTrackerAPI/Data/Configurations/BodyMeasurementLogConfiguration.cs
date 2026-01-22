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

            var user1Id = Guid.Parse("42A01733-E4B8-46C0-95C0-CD178CA92D1C"); // Jan
            var user2Id = Guid.Parse("C63780C7-30DF-4829-89A8-27B34463452A"); // Anna

            builder.HasData(
                new BodyMeasurementLog
                {
                    Id = new Guid("ADB970AE-529F-47A2-A3AD-E197D35ED0E3"),
                    UserId = user1Id,
                    Weight = 90.50m,
                    LoggedAt = new DateTimeOffset(2023, 10, 01, 8, 0, 0, TimeSpan.Zero)
                },
                new BodyMeasurementLog
                {
                    Id = new Guid("BDFF751B-845D-4851-9AFC-93DB8FBE1F8F"),
                    UserId = user1Id,
                    Weight = 89.20m,
                    LoggedAt = new DateTimeOffset(2023, 10, 15, 8, 30, 0, TimeSpan.Zero)
                },
                new BodyMeasurementLog
                {
                    Id = new Guid("C3E71846-4552-4731-B52B-6D6498B09871"),
                    UserId = user1Id,
                    Weight = 88.00m,
                    LoggedAt = new DateTimeOffset(2023, 11, 01, 7, 45, 0, TimeSpan.Zero)
                },
                new BodyMeasurementLog
                {
                    Id = new Guid("501FEF62-04FC-4A27-A910-A6C1698B1257"),
                    UserId = user2Id,
                    Weight = 65.00m,
                    LoggedAt = new DateTimeOffset(2023, 10, 05, 9, 0, 0, TimeSpan.Zero)
                },
                new BodyMeasurementLog
                {
                    Id = new Guid("91627900-C250-4CBA-B530-01C8CA0BEE1F"),
                    UserId = user2Id,
                    Weight = 64.10m,
                    LoggedAt = new DateTimeOffset(2023, 10, 20, 8, 15, 0, TimeSpan.Zero)
                }
               );
        }
    }
}
