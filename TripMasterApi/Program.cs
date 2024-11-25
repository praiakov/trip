using Microsoft.EntityFrameworkCore;
using TripApplication.ManageRoutes;
using TripApplication.SearchTrip;
using TripDomain.Interfaces;
using TripInfra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IManageRoutes, ManageRoutes>();
builder.Services.AddScoped<ISearchTrip, SearchTrip>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TripContext>(o =>
{
    o.UseInMemoryDatabase("TripDb");
});

var app = builder.Build();

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
