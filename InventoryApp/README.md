# InventoryApp - RESTful API

A modern, robust Inventory Management Backend built with ASP.NET Core. This project demonstrates clean code principles, layered architecture, and professional error handling in a .NET environment.

##  Technologies Used
* **Framework:** .NET 8 (ASP.NET Core Web API)
* **Database & ORM:** SQL Server with Entity Framework Core
* **Mapping:** AutoMapper (for DTO-to-Entity separation)
* **Documentation:** Swagger / OpenAPI
* **Error Handling:** Custom Middleware for Global Exception Management

##  Architecture & Patterns
The project follows industry-standard design patterns to ensure scalability and maintainability:
* **Repository Pattern:** Decouples data access logic from the business layer for better testability.
* **DTO (Data Transfer Objects):** Separates the API contract from the internal database schema.
* **Dependency Injection:** Ensures loose coupling between components.
* **Async/Await:** Implements non-blocking I/O operations for better performance under load.

##  Getting Started
1. **Clone the repository:** `git clone https://github.com/Grosh69/inventory_app.git`
2. **Database Setup:** Update the `DefaultConnection` string in `appsettings.json`.
3. **Migrations:** Run `Update-Database` in the Package Manager Console.
4. **Run:** Press F5 to start the application. The Swagger UI will be available at `/swagger`.

## Features
- Full CRUD operations for Inventory items.
- Case-insensitive search by product name.
- Server-side data validation using Data Annotations.
- Global exception handling providing consistent JSON error responses.