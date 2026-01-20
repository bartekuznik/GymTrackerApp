using GymTrackerAPI.Configurations;
using GymTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conectionString = builder.Configuration.GetConnectionString("GymTrackerDbContextConnectionString");
builder.Services.AddDbContext<GymTrackerDbContext>(options =>
{
    options.UseSqlServer(conectionString);
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
