using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryMuscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryMuscleGroups = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Height = table.Column<short>(type: "smallint", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyMeasurementLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    LoggedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyMeasurementLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyMeasurementLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    FoodName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(6,1)", precision: 6, scale: 1, nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: false, defaultValue: 0m),
                    Carbs = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: false, defaultValue: 0m),
                    Fat = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoggedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    AmountMilliliters = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    StartAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<short>(type: "smallint", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    Reps = table.Column<short>(type: "smallint", nullable: true),
                    RestTime = table.Column<short>(type: "smallint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSets_WorkoutExercises_WorkoutExerciseId",
                        column: x => x.WorkoutExerciseId,
                        principalTable: "WorkoutExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name", "PrimaryMuscleGroup", "SecondaryMuscleGroups", "Type" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), "Wyciskanie sztangi na ławce poziomej", "Chest", "Triceps", "Bodyweight" },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), "Martwy ciąg", "LowerBack", "Hamstrings", "Bodyweight" },
                    { new Guid("a3333333-3333-3333-3333-333333333333"), "Przysiady ze sztangą", "Quadriceps", "Glutes", "Bodyweight" },
                    { new Guid("a4444444-4444-4444-4444-444444444444"), "Podciąganie na drążku", "Lats", "Biceps", "Bodyweight" },
                    { new Guid("a5555555-5555-5555-5555-555555555555"), "Wyciskanie żołnierskie (OHP)", "AnteriorDeltoid", "Triceps", "Bodyweight" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Height", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c"), 0, new DateTimeOffset(new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "72f1fe04-94e1-44ed-a21e-90d6d40a0b01", "jan.kowalski@example.com", true, "Jan", (short)185, "Kowalski", false, null, "JAN.KOWALSKI@EXAMPLE.COM", "JAN.KOWALSKI@EXAMPLE.COM", "AQAAAAIAAYagAAAAEI0LvnzreqcLER50jX7JZlNJBzluAVZHqflQc418ZpVeNo0OHtb8+zS4jfM4MalfnQ==", null, false, "5DFFFC21-70C5-411B-81D0-59B3F991399A", false, "jan.kowalski@example.com" },
                    { new Guid("c63780c7-30df-4829-89a8-27b34463452a"), 0, new DateTimeOffset(new DateTime(1995, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "6dfa5176-72ae-4346-9137-a44a2242375a", "anna.nowak@example.com", true, "Anna", (short)168, "Nowak", false, null, "ANNA.NOWAK@EXAMPLE.COM", "ANNA.NOWAK@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHmjudwy4GO0f1JqXKsxV5fD3gtA7KC68IWiaTwO+J6nAMzVT/P+9D9hMtxsU3ijCg==", null, false, "051F0548-C920-4511-8829-5A712DF06206", false, "anna.nowak@example.com" }
                });

            migrationBuilder.InsertData(
                table: "BodyMeasurementLogs",
                columns: new[] { "Id", "LoggedAt", "UserId", "Weight" },
                values: new object[,]
                {
                    { new Guid("501fef62-04fc-4a27-a910-a6c1698b1257"), new DateTimeOffset(new DateTime(2023, 10, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c63780c7-30df-4829-89a8-27b34463452a"), 65.00m },
                    { new Guid("91627900-c250-4cba-b530-01c8ca0bee1f"), new DateTimeOffset(new DateTime(2023, 10, 20, 8, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c63780c7-30df-4829-89a8-27b34463452a"), 64.10m },
                    { new Guid("adb970ae-529f-47a2-a3ad-e197d35ed0e3"), new DateTimeOffset(new DateTime(2023, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c"), 90.50m },
                    { new Guid("bdff751b-845d-4851-9afc-93db8fbe1f8f"), new DateTimeOffset(new DateTime(2023, 10, 15, 8, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c"), 89.20m },
                    { new Guid("c3e71846-4552-4731-b52b-6d6498b09871"), new DateTimeOffset(new DateTime(2023, 11, 1, 7, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c"), 88.00m }
                });

            migrationBuilder.InsertData(
                table: "NutritionLogs",
                columns: new[] { "Id", "Calories", "Carbs", "ConsumedAt", "Fat", "FoodName", "Protein", "UserId" },
                values: new object[,]
                {
                    { new Guid("2edaf838-fb7e-42be-99b5-e2eeb577ad3a"), 320.0m, 12.0m, new DateTimeOffset(new DateTime(2023, 11, 2, 20, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 22.5m, "Jogurt Grecki z orzechami", 18.2m, new Guid("c63780c7-30df-4829-89a8-27b34463452a") },
                    { new Guid("7995fe93-1a63-417d-a347-fc7c1aae62af"), 210.0m, 5.0m, new DateTimeOffset(new DateTime(2023, 11, 2, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3.2m, "Shake proteinowy", 30.0m, new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c") },
                    { new Guid("cde21408-1258-4019-b148-c40ee67cebdf"), 620.0m, 70.0m, new DateTimeOffset(new DateTime(2023, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10.2m, "Kurczak z ryżem i brokułami", 45.5m, new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c") },
                    { new Guid("d0c29fa2-8e25-40f9-944e-be4cae271e34"), 450.5m, 65.2m, new DateTimeOffset(new DateTime(2023, 11, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 12.5m, "Owsianka z borówkami", 15.0m, new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c") },
                    { new Guid("e6646985-fd2f-4e16-b68a-3b50d55d9cf1"), 540.0m, 15.5m, new DateTimeOffset(new DateTime(2023, 11, 2, 13, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 38.0m, "Sałatka Cezar", 28.0m, new Guid("c63780c7-30df-4829-89a8-27b34463452a") }
                });

            migrationBuilder.InsertData(
                table: "WaterLogs",
                columns: new[] { "Id", "AmountMilliliters", "LoggedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1e013160-1b9c-4c97-883f-cb19d6776fb6"), (short)500, new DateTimeOffset(new DateTime(2023, 11, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c") },
                    { new Guid("4fd58b38-c44b-495b-ac6f-cbac2f1fb93e"), (short)330, new DateTimeOffset(new DateTime(2023, 11, 3, 14, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c63780c7-30df-4829-89a8-27b34463452a") },
                    { new Guid("637fa87d-e041-4f57-9c05-50fb84b3a6a2"), (short)250, new DateTimeOffset(new DateTime(2023, 11, 3, 7, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c") },
                    { new Guid("7b582aa4-dfea-4713-8d82-8e788391a3f1"), (short)200, new DateTimeOffset(new DateTime(2023, 11, 3, 21, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c63780c7-30df-4829-89a8-27b34463452a") },
                    { new Guid("aa7b4a50-de7c-480e-9c9f-4f49ad7f534d"), (short)330, new DateTimeOffset(new DateTime(2023, 11, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c63780c7-30df-4829-89a8-27b34463452a") }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "EndAt", "Name", "Notes", "StartAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new DateTimeOffset(new DateTime(2023, 11, 4, 18, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Siła - Klatka i Plecy", "Bardzo dobra sesja, progres w martwym ciągu.", new DateTimeOffset(new DateTime(2023, 11, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("42a01733-e4b8-46c0-95c0-cd178ca92d1c") },
                    { new Guid("d2222222-2222-2222-2222-222222222222"), new DateTimeOffset(new DateTime(2023, 11, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "FBW - Start", "Skupienie na technice.", new DateTimeOffset(new DateTime(2023, 11, 4, 9, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c63780c7-30df-4829-89a8-27b34463452a") }
                });

            migrationBuilder.InsertData(
                table: "WorkoutExercises",
                columns: new[] { "Id", "ExerciseId", "Order", "WorkoutId" },
                values: new object[,]
                {
                    { new Guid("c1111111-e111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111"), (short)1, new Guid("c1111111-1111-1111-1111-111111111111") },
                    { new Guid("c1111111-e222-1111-1111-111111111111"), new Guid("a2222222-2222-2222-2222-222222222222"), (short)2, new Guid("c1111111-1111-1111-1111-111111111111") },
                    { new Guid("d2222222-e111-2222-2222-222222222222"), new Guid("a1111111-1111-1111-1111-111111111111"), (short)1, new Guid("d2222222-2222-2222-2222-222222222222") },
                    { new Guid("d2222222-e222-2222-2222-222222222222"), new Guid("a2222222-2222-2222-2222-222222222222"), (short)2, new Guid("d2222222-2222-2222-2222-222222222222") }
                });

            migrationBuilder.InsertData(
                table: "WorkoutSets",
                columns: new[] { "Id", "IsCompleted", "Order", "Reps", "RestTime", "Type", "Weight", "WorkoutExerciseId" },
                values: new object[,]
                {
                    { new Guid("12a6049c-262c-43f2-888f-8593dcf79e3e"), true, (short)1, (short)12, null, "Warmup", 30.00m, new Guid("d2222222-e111-2222-2222-222222222222") },
                    { new Guid("2fed9eb5-43d6-4207-8262-363d64242295"), true, (short)1, (short)10, null, "Work", 50.00m, new Guid("d2222222-e222-2222-2222-222222222222") },
                    { new Guid("43e759dd-91f6-4071-9fb2-da82366d36a1"), true, (short)1, (short)10, null, "Work", 80.00m, new Guid("c1111111-e111-1111-1111-111111111111") },
                    { new Guid("4f2811d9-5733-46b6-85b8-bef6714841dd"), true, (short)2, (short)10, null, "Work", 40.00m, new Guid("d2222222-e111-2222-2222-222222222222") },
                    { new Guid("668148b6-def7-472f-b5db-0b64027eb618"), true, (short)1, (short)5, null, "Work", 120.00m, new Guid("c1111111-e222-1111-1111-111111111111") },
                    { new Guid("ba0021ef-d9d3-4efc-83f0-7df2a7134612"), true, (short)2, (short)3, null, "Work", 130.00m, new Guid("c1111111-e222-1111-1111-111111111111") },
                    { new Guid("d4ef5a40-4437-4fcb-8b72-ea994924423c"), true, (short)2, (short)8, null, "Work", 55.00m, new Guid("d2222222-e222-2222-2222-222222222222") },
                    { new Guid("d665bddf-b970-4d0a-b3d6-e8602693ac09"), true, (short)2, (short)8, null, "Work", 85.00m, new Guid("c1111111-e111-1111-1111-111111111111") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurementLog_User_Date",
                table: "BodyMeasurementLogs",
                columns: new[] { "UserId", "LoggedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_Name",
                table: "Exercises",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NutritionLog_User_Date",
                table: "NutritionLogs",
                columns: new[] { "UserId", "ConsumedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastName",
                table: "Users",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WaterLog_User_Date",
                table: "WaterLogs",
                columns: new[] { "UserId", "LoggedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_WorkoutId_Order",
                table: "WorkoutExercises",
                columns: new[] { "WorkoutId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_Workout_UserId_StartAt",
                table: "Workouts",
                columns: new[] { "UserId", "StartAt" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSet_ExerciseId_Order",
                table: "WorkoutSets",
                columns: new[] { "WorkoutExerciseId", "Order" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyMeasurementLogs");

            migrationBuilder.DropTable(
                name: "NutritionLogs");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "WaterLogs");

            migrationBuilder.DropTable(
                name: "WorkoutSets");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "WorkoutExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
