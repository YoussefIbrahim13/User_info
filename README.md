# user_info

ASP.NET Core Web API project for managing user information.

## Features
- Add a new user with CV file upload
- View user data
- Uses Entity Framework Core with SQL Server
- Organized code with DTOs, Models, and Controllers

## Requirements
- .NET 8.0 or later
- SQL Server (e.g., SQLEXPRESS01)

## Getting Started
1. Make sure SQL Server is installed and running on your machine.
2. Update the database connection string in `appsettings.json` if needed.
3. From the project folder, run:
   ```powershell
   dotnet ef database update
   dotnet run
   ```
4. Use tools like Postman or any HTTP client to test the API.

## Project Structure
- `Controllers/` : API controllers
- `Models/` : Data models and DTOs
- `Data/` : Database context
- `Migrations/` : Database migration files

## Example: Add User
```json
{
  "fname": "Ahmed",
  "lname": "Ali",
  "email": "ahmed@example.com",
  "phone": "0123456789",
  "cvFile": "(attached file)"
}
```

## License
This project is open source and free to use and modify.

