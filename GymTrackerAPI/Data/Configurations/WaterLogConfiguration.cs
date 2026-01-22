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

            var user1Id = Guid.Parse("42A01733-E4B8-46C0-95C0-CD178CA92D1C"); // Jan
            var user2Id = Guid.Parse("C63780C7-30DF-4829-89A8-27B34463452A"); // Anna

            builder.HasData(
                new WaterLog
                {
                    Id = new Guid("637FA87D-E041-4F57-9C05-50FB84B3A6A2"),
                    UserId = user1Id,
                    AmountMilliliters = 250, 
                    LoggedAt = new DateTimeOffset(2023, 11, 03, 7, 15, 0, TimeSpan.Zero)
                },
                new WaterLog
                {
                    Id = new Guid("1E013160-1B9C-4C97-883F-CB19D6776FB6"),
                    UserId = user1Id,
                    AmountMilliliters = 500, 
                    LoggedAt = new DateTimeOffset(2023, 11, 03, 18, 00, 0, TimeSpan.Zero)
                },
                new WaterLog
                {
                    Id = new Guid("AA7B4A50-DE7C-480E-9C9F-4F49AD7F534D"),
                    UserId = user2Id,
                    AmountMilliliters = 330, 
                    LoggedAt = new DateTimeOffset(2023, 11, 03, 10, 30, 0, TimeSpan.Zero)
                },
                new WaterLog
                {
                    Id = new Guid("4FD58B38-C44B-495B-AC6F-CBAC2F1FB93E"),
                    UserId = user2Id,
                    AmountMilliliters = 330, 
                    LoggedAt = new DateTimeOffset(2023, 11, 03, 14, 45, 0, TimeSpan.Zero)
                },
                new WaterLog
                {
                    Id = new Guid("7B582AA4-DFEA-4713-8D82-8E788391A3F1"),
                    UserId = user2Id,
                    AmountMilliliters = 200,
                    LoggedAt = new DateTimeOffset(2023, 11, 03, 21, 20, 0, TimeSpan.Zero)
                }
            );
        }
    }
}
