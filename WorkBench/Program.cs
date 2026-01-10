using WorkBench.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WorkBenchDbContext>();

var app = builder.Build();

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
