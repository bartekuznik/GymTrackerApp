using GymTrackerAPI.Configurations;
using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conectionString = builder.Configuration.GetConnectionString("GymTrackerDbContextConnectionString");
builder.Services.AddDbContext<GymTrackerDbContext>(options =>
{
    options.UseSqlServer(conectionString);
});
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<GymTrackerDbContext>()
    .AddDefaultTokenProviders(); ;

builder.Services.AddScoped(typeof(IGenericsRepository<>), typeof(GenericsRepository<>));
builder.Services.AddScoped<IExercisesRepository, ExercisesRepository>();
builder.Services.AddScoped<IBodyMeasurementLogsRepository, BodyMeasurementLogsRepository>();
builder.Services.AddScoped<INutritionLogsRepository, NutritionLogsRepository>();
builder.Services.AddScoped<IWaterLogsRepository, WaterLogsRepository>();
builder.Services.AddScoped<IWorkoutSetsRepository, WorkoutSetsRepository>();
builder.Services.AddScoped<IWorkoutExercisesRepository, WorkoutExercisesRepository>();
builder.Services.AddScoped<IWorkoutsRepository, WorkoutsRepository>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

var issuer = builder.Configuration["JwtSettings:Issuer"];
var audience = builder.Configuration["JwtSettings:Audience"];
var key = builder.Configuration["JwtSettings:Key"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); //w enum zmiana z liczby na wartoœc

builder.Services.AddCors(options => //CORS
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new MapperConfig());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); //dodaæ
    app.UseSwaggerUI(); // dodaæ
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
