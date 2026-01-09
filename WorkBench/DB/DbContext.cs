namespace WorkBench.DB
{
    using Microsoft.EntityFrameworkCore;
    using WorkBench.Models;

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Change the connection string to your local SQL instance
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WorkBenchDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Persons
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FullName = "Anton Robins" },
                new Person { Id = 2, FullName = "John Smith" }
            );

            // Seed Tasks
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Programming", Description = "Coding new requirements or fixing existing ones" },
                new TaskItem { Id = 2, Title = "Testing", Description = "Testing the new or revised functionality to make sure everything runs smooth" }
            );
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
    }
}
