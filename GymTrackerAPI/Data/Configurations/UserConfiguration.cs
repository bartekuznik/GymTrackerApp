using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerAPI.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.BirthDate)
                .IsRequired();

            builder.Property(x => x.Height)
                .IsRequired(false);

            builder.HasIndex(x => x.LastName);


            var user1 = new User
            {
                Id = Guid.Parse("42A01733-E4B8-46C0-95C0-CD178CA92D1C"),
                FirstName = "Jan",
                LastName = "Kowalski",
                BirthDate = new DateTimeOffset(1990, 5, 20, 0, 0, 0, TimeSpan.Zero),
                Height = 185,
                UserName = "jan.kowalski@example.com",
                NormalizedUserName = "JAN.KOWALSKI@EXAMPLE.COM",
                Email = "jan.kowalski@example.com",
                NormalizedEmail = "JAN.KOWALSKI@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "5DFFFC21-70C5-411B-81D0-59B3F991399A",
                PasswordHash = "AQAAAAIAAYagAAAAEI0LvnzreqcLER50jX7JZlNJBzluAVZHqflQc418ZpVeNo0OHtb8+zS4jfM4MalfnQ==",
                ConcurrencyStamp = "72f1fe04-94e1-44ed-a21e-90d6d40a0b01"
            };
            

            var user2 = new User
            {
                Id = Guid.Parse("C63780C7-30DF-4829-89A8-27B34463452A"),
                FirstName = "Anna",
                LastName = "Nowak",
                BirthDate = new DateTimeOffset(1995, 10, 12, 0, 0, 0, TimeSpan.Zero),
                Height = 168,
                UserName = "anna.nowak@example.com",
                NormalizedUserName = "ANNA.NOWAK@EXAMPLE.COM",
                Email = "anna.nowak@example.com",
                NormalizedEmail = "ANNA.NOWAK@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "051F0548-C920-4511-8829-5A712DF06206",
                PasswordHash = "AQAAAAIAAYagAAAAEHmjudwy4GO0f1JqXKsxV5fD3gtA7KC68IWiaTwO+J6nAMzVT/P+9D9hMtxsU3ijCg==",
                ConcurrencyStamp = "6dfa5176-72ae-4346-9137-a44a2242375a"
            };
            

            builder.HasData(user1, user2);
        }
    }
}
