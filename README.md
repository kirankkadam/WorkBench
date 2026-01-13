# Timesheet Management System
A full-stack application designed to track employee work hours against specific tasks. It features a robust C# .NET 10 backend using the Repository pattern and a modern Angular 21 frontend utilizing Signals and Reactive Forms.

## Key Functionality
Automated DB Setup: Local SQL database is automatically created and seeded with dummy People and Tasks on first run.

- Data Persistence: Uses Entity Framework Core 9 for relational data mapping.
- Clean Architecture: Separation of concerns via Services, Repositories, and a Unit of Work.
- Reactive UI: Angular 21 frontend with real-time validation and state management via Signals.
- Timesheet Logging: User-friendly form with validation for hours, dates, and associations.

## Technologies Used
- ### Backend (.NET Core 10)
  - Entity Framework Core 9: ORM for database operations.
  - SQL Server (LocalDB): Lightweight local database.
  - Repository & Unit of Work: Design patterns for clean data access.
- ### Frontend (Angular 21)
  - Angular Signals: For reactive state management.
  - Standalone Components: Lightweight, modular UI structure.
  - Reactive Forms: For complex validation logic.
  - RxJS & HttpClient: For asynchronous API communication.
 
## Getting Started
1. Start the Web API
  - Navigate to the API project folder: cd Timesheet.API
  - Open AppDbContext.cs and ensure the connection string points to your local SQL instance.
Run the application:
Bash

dotnet run
__Note:__ On the first execution, db.Database.EnsureCreated() will trigger. This will create TimesheetDb in your LocalDB and seed it with Alice, Bob, and initial tasks.
