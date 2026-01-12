using Microsoft.EntityFrameworkCore.Metadata;
using WorkBench.DB;
using WorkBench.Models;
using WorkBench.Repository;
using WorkBench.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
                                          builder =>
                                          {
                                              builder.WithOrigins("http://localhost:4200")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                                          });
});
builder.Services.AddSingleton<WorkBenchDbContext>();
builder.Services.AddScoped<IRepository<Timesheet>, Repository<Timesheet>>();

var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

using var db = new WorkBenchDbContext();

// This creates the database and seeds the data if it doesn't exist
Console.WriteLine("Ensuring database is created...");
db.Database.EnsureCreated();

// Fetch and display data to verify
var persons = db.Persons.ToList();
Console.WriteLine($"Database initialized with {persons.Count} people.");

foreach (var person in persons)
{
    Console.WriteLine($"- {person.FullName}");
}

Console.WriteLine("Ready to log timesheets!");

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
