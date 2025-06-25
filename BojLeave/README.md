# BojLeave

A .NET 8 Leave Management System following Domain-Driven Design (DDD).

## Structure
- **BojLeave.Api**: ASP.NET Core Web API (Presentation Layer)
- **BojLeave.Application**: Application Layer (Use Cases, Services)
- **BojLeave.Domain**: Domain Layer (Entities, Aggregates, Value Objects, Domain Services)
- **BojLeave.Infrastructure**: Infrastructure Layer (Data Access, External Integrations)

## Features
- Login and Authentication (to be implemented)
- Leave request management (to be implemented)

## Getting Started
1. Build the solution:
   ```powershell
   dotnet build
   ```
2. Run the API:
   ```powershell
   dotnet run --project BojLeave.Api
   ```

## Requirements
- .NET 8 SDK

---
This project is scaffolded for DDD and ready for further development.
