using GymTrackerAPI.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Data
{
    public class GymTrackerDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid> //musimy okreslić więcej parametrów bo zmieniamy Id na GUID
    {
        public GymTrackerDbContext(DbContextOptions<GymTrackerDbContext> options) : base(options)
        {

        }

        public DbSet<BodyMeasurementLog> BodyMeasurementLogs { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<NutritionLog> NutritionLogs { get; set; }
        public DbSet<WaterLog> WaterLogs { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<WorkoutSet> WorkoutSets { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole<Guid>>().ToTable("Roles");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

            //builder.ApplyConfiguration(new BodyMeasurementLogConfiguration());
            //builder.ApplyConfiguration(new ExerciseConfiguration());
            //builder.ApplyConfiguration(new NutritionLogConfiguration());
            //builder.ApplyConfiguration(new WaterLogConfiguration());
            //builder.ApplyConfiguration(new WorkoutConfiguration());
            //builder.ApplyConfiguration(new WorkoutExerciseConfiguration());
            //builder.ApplyConfiguration(new WorkoutSetConfiguration());

            builder.ApplyConfigurationsFromAssembly(typeof(GymTrackerDbContext).Assembly); //automatycznie znajdzie Configurations po implemntaji IEntityTypeConfiguration więc powyżej jest koment
        }
    }
}
