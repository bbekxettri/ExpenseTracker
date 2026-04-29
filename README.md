# ExpenseTracker API

ExpenseTracker is a clean, layered ASP.NET Core Web API for tracking personal accounts, categories, and transactions. It uses JWT authentication, PostgreSQL, Entity Framework Core, and a solution structure that separates API, application, domain, and infrastructure concerns.

## Features

- User registration and login with BCrypt password hashing
- JWT bearer authentication across protected endpoints
- Per-user accounts, categories, and transactions
- CRUD endpoints for accounts, categories, and transactions
- Data validation with meaningful 400 responses
- ProblemDetails error responses for auth, conflict, and server errors
- Entity Framework Core migrations for PostgreSQL
- Swagger/OpenAPI configured with bearer-token support

## Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- JWT Bearer authentication
- BCrypt.Net
- Swagger / Swashbuckle

## Project Structure

```text
src/
  ExpenseTracker.API/             HTTP controllers, auth pipeline, Swagger, middleware
  ExpenseTracker.Application/     DTOs, service contracts, business services, mappings
  ExpenseTracker.Domain/          Entities and enums
  ExpenseTracker.Infrastructure/  EF Core DbContext, migrations, repositories, JWT service
```

## Getting Started

### Prerequisites

- .NET SDK 8
- Docker, or a local PostgreSQL instance

### Run PostgreSQL with Docker

```bash
docker compose up -d
```

### Configure the API

Set these values in `src/ExpenseTracker.API/appsettings.Development.json` or with user secrets:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5431;Database=ExpenseTrackerDb;Username=postgres;Password=postgres;SSL Mode=Disable"
  },
  "Jwt": {
    "Issuer": "ExpenseTracker",
    "Audience": "ExpenseTracker",
    "Secret": "replace-with-a-long-development-secret"
  }
}
```

### Apply Migrations

```bash
dotnet ef database update --project src/ExpenseTracker.Infrastructure --startup-project src/ExpenseTracker.API
```

### Run the API

```bash
dotnet run --project src/ExpenseTracker.API
```

Open Swagger in development at:

```text
https://localhost:7094/swagger
```

## API Overview

Public endpoints:

- `POST /api/auth/register`
- `POST /api/auth/login`

Authenticated endpoints:

- `GET /api/accounts`
- `POST /api/accounts`
- `PUT /api/accounts/{id}`
- `DELETE /api/accounts/{id}`
- `GET /api/categories`
- `POST /api/categories`
- `PUT /api/categories/{id}`
- `DELETE /api/categories/{id}`
- `GET /api/transactions`
- `POST /api/transactions`
- `PUT /api/transactions/{id}`
- `DELETE /api/transactions/{id}`

## Development Notes

- The API returns `application/problem+json` for handled errors.
- DTO validation is enforced automatically by `[ApiController]`.
- All account, category, and transaction reads are scoped to the authenticated user.
- Package versions are managed centrally in `Directory.Packages.props`.

## Future Improvements

- Add automated unit and integration tests
- Add pagination and filtering for transaction history
- Validate transfer transactions against account ownership
- Add CI with `dotnet format`, `dotnet build`, and tests
