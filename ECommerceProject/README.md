# 🛒 ECommerce API

 ASP.NET Core Web API for an e-commerce system built using clean architecture principles.

## 🚀 Features
- JWT Authentication & Authorization
- User Management
- Product Management (CRUD)
- Category Management
- Order Management
- Repository Pattern
- Service Layer Architecture
- FluentValidation for request validation
- Global Exception Handling Middleware
- DTO-based design
- Swagger API documentation

## 🛠 Tech Stack
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- JWT Authentication
- FluentValidation
- Swagger / OpenAPI

## 📁 Project Structure
- Controllers
- Services
- Repository
- Interfaces
- DTOs
- Models
- Data
- Middleware
- Validation
- Helpers
- Migrations
- Program.cs
- appsettings.example.json

## ⚙️ Setup Instructions

- Configure app settings:
  - Copy appsettings.example.json
  - Rename it to appsettings.json
  - Add your own:
    - Database connection string
    - JWT Key, Issuer, Audience

- Run the project:
  - dotnet restore
  - dotnet ef database update
  - dotnet run



## 📌 Note
- This is a learning + portfolio backend project built with ASP.NET Core Web API