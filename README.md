# Timesheet Management System
A full-stack application designed to track employee work hours against specific tasks. It features a robust C# .NET 10 backend using the Repository pattern and a modern Angular 21 frontend utilizing Signals and Reactive Forms.

## Key Functionality
Automated DB Setup: Local SQL database is automatically created and seeded with dummy People and Tasks on first run.

- Data Persistence: Uses Entity Framework Core 10 for relational data mapping.
- Clean Architecture: Separation of concerns via Services, Repositories.
- Reactive UI: Angular 21 frontend with real-time validation and state management via Signals.
- Timesheet Logging: User-friendly form with validation for hours, dates, and associations.

## Technologies Used
- ### Backend (.NET Core 10)
  - Entity Framework Core 10: ORM for database operations.
  - SQL Server (LocalDB): Lightweight local database.
  - Repository pattern: Design patterns for clean data access.
- ### Frontend (Angular 21)
  - Angular Signals: For reactive state management.
  - Standalone Components: Lightweight, modular UI structure.
  - Reactive Forms: For complex validation logic.
  - RxJS & HttpClient: For asynchronous API communication.
 
## Getting Started
### Web Api
1. Open the solution in Visual studio 2022.
2. Make sure the connection string in  WorkBenchDbContext.cs file is pointing to LocalDb.
3. Start the Web Api by hitting F5 or the play button. On successful execution it should display the swagger page.

__Note:__ On the first execution, db.Database.EnsureCreated() will trigger. This will create WorkBenchDb in your LocalDB and seed it with 2 users __Anton Robins__ and __John Smith__, also it will seed 2 tasks __Programming__ and __Testing__.

### Angular UI
1. Navigate to the Angular project folder
```
cd WorkBench.App
```
2. Install dependencies:
```
npm install
```
3. Ensure the apiUrl in src/app/base/base.service.ts matches your .NET API URL (usually https://localhost:44374/).
4. Launch the development server
```
ng serve
```
5. Open your browser to http://localhost:4200.
6. The timesheet screen is the default landing page.
7. There are 3 menu options on the top navigation bar: Timesheets, People, and Tasks.
8. People view is a read only screen with a list of seeded users.
9. Tasks view is a read only screen with a list of seeded tasks.

## Screenshots
### Timesheet Entry Form
