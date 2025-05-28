# ProductApi

A clean, lightweight ASP.NET Core Web API for managing products. Built with Entity Framework Core and SQLite, this project supports full CRUD operations and is testable via Swagger UI.

---

## Features

- RESTful endpoints for full product CRUD
- EF Core code-first with SQLite database
- Dependency Injection and clean architecture
- Async/await for scalable request handling
- Auto-generated API docs and testing via Swagger

---

## Tech Stack

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

---

## Endpoints Overview

| Method | Route                 | Description               |
|--------|-----------------------|---------------------------|
| GET    | `/api/products`       | Get all products          |
| GET    | `/api/products/{id}`  | Get product by ID         |
| POST   | `/api/products`       | Create a new product      |
| PUT    | `/api/products/{id}`  | Update an existing product |
| DELETE | `/api/products/{id}`  | Delete a product by ID    |

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- Visual Studio 2022 or newer (or CLI)
- Git

### Setup Instructions

**1. Clone the repo**

    git clone https://github.com/edmaccarone/portfolio-productApi.git
    cd ProductApi

**2. Restore dependencies**

    dotnet restore

**3. Apply database migrations**

    dotnet ef database update

**4. Run the project**

    dotnet run

**5. Open Swagger UI**

    Navigate to:  
    https://localhost:7040/swagger