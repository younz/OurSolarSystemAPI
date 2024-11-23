using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Repository;
using OurSolarSystemAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OurSolarSystemContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 2)) // Adjust based on your MySQL version
    )
);

// Register HttpClient
builder.Services.AddHttpClient();

// Register other services
builder.Services.AddScoped<ScrapingService>();
builder.Services.AddScoped<BarycenterRepository>();
builder.Services.AddScoped<PlanetRepository>();
builder.Services.AddScoped<ArtificialSatelliteRepository>();
builder.Services.AddScoped<ScrapingService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<OurSolarSystemContext>();
        dbContext.Database.EnsureCreated(); // This creates the database if it does not exist
    }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
