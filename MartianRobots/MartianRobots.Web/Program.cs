using MartianRobots.Core;
using MartianRobots.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IExploreService, ExploreService>();
builder.Services.AddSingleton<ITopScoreRepository, TopScoreRepositoryInMemory>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
