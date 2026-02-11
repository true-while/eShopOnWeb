[![Build Status](https://github.com/dotnet-architecture/eShopOnWeb/workflows/eShopOnWeb%20Build%20and%20Test/badge.svg)](https://github.com/dotnet-architecture/eShopOnWeb/actions)

# Microsoft eShopOnWeb ASP.NET Core Reference Application

## Overview

eShopOnWeb is a sample ASP.NET Core reference application demonstrating a single-process (monolithic) application architecture and deployment model. This application is designed to showcase best practices for building modern web applications using ASP.NET Core, Entity Framework Core, and Clean Architecture principles.

**Target Audience:** Developers learning ASP.NET Core or architects looking for reference patterns for monolithic web applications. If you're new to .NET development, read the [Getting Started for Beginners](https://github.com/dotnet-architecture/eShopOnWeb/wiki/Getting-Started-for-Beginners) guide.

**Key Resources:**
- [Frequently Asked Questions](https://github.com/dotnet-architecture/eShopOnWeb/wiki/Frequently-Asked-Questions)
- [Getting Started Guide](https://github.com/dotnet-architecture/eShopOnWeb/wiki/Getting-Started-for-Beginners)

## What is eShopOnWeb?

eShopOnWeb is a simplified e-commerce web application built with ASP.NET Core. Unlike its microservices-based counterpart [eShopOnContainers](https://github.com/dotnet/eShopOnContainers), this application focuses on traditional web development with a single deployment model, making it ideal for understanding core ASP.NET Core concepts without the complexity of distributed systems.

**Important Note:** This is a reference application for learning purposes. It is not intended to be a production-ready e-commerce platform and intentionally omits many features that would be essential in a real e-commerce application.

## Architecture

The application follows Clean Architecture principles with clear separation of concerns:

### Project Structure

- **Web** - ASP.NET Core MVC application (Presentation Layer)
  - Razor Pages and MVC Controllers
  - View Models and UI logic
  - Blazor WebAssembly components for admin features
  
- **ApplicationCore** - Core business logic (Domain Layer)
  - Domain entities and aggregates
  - Business logic and domain services
  - Repository interfaces
  - Specifications pattern for queries
  
- **Infrastructure** - Data access and external services (Infrastructure Layer)
  - Entity Framework Core data contexts
  - Repository implementations
  - Data seeding and migrations
  - External service integrations

- **PublicApi** - RESTful API using API Endpoints pattern
  - Alternative to traditional controller-based APIs
  - Demonstrates minimal API endpoint pattern
  
- **BlazorAdmin** - Blazor WebAssembly admin interface
  - Client-side Blazor application
  - Admin functionality for managing catalog items
  
- **BlazorShared** - Shared Blazor components and models

### Technology Stack

- **.NET 7.0** - Framework version
- **ASP.NET Core MVC** - Web framework with Razor Pages
- **Entity Framework Core** - ORM for data access
- **Blazor WebAssembly** - Client-side admin interface
- **SQL Server** - Primary database (or In-Memory for development)
- **Docker** - Container support for deployment
- **Azure** - Cloud deployment options

### Design Patterns & Practices

- **Clean Architecture** - Dependency inversion and separation of concerns
- **Repository Pattern** - Data access abstraction
- **Specification Pattern** - Query logic encapsulation  
- **MediatR** - CQRS-style command/query handling
- **Dependency Injection** - Built-in ASP.NET Core DI
- **AutoMapper** - Object-to-object mapping

## Features

- **Product Catalog** - Browse and search products by category and brand
- **Shopping Basket** - Add items to cart and manage quantities
- **User Authentication** - Identity management with ASP.NET Core Identity
- **Order Management** - Create and view orders
- **Admin Interface** - Blazor-based admin panel for catalog management
- **RESTful API** - Public API for external integrations
- **Responsive Design** - Mobile-friendly UI

## Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) or later
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (LocalDB, Express, or full edition) OR use in-memory database
- [Docker](https://www.docker.com/products/docker-desktop) (optional, for containerized deployment)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), or [JetBrains Rider](https://www.jetbrains.com/rider/)

A list of Frequently Asked Questions about this repository can be found [here](https://github.com/dotnet-architecture/eShopOnWeb/wiki/Frequently-Asked-Questions).

## Learning Resources

### eBook

This application accompanies the free eBook: [**Architecting Modern Web Applications with ASP.NET Core and Azure**](https://aka.ms/webappebook), updated to **ASP.NET Core 7.0**.

[<img src="https://dotnet.microsoft.com/blob-assets/images/e-books/aspnet.png" height="300" />](https://dotnet.microsoft.com/learn/web/aspnet-architecture)

**Available formats:**
- [PDF Download](https://aka.ms/webappebook)
- [ePub/Mobi formats](https://dotnet.microsoft.com/learn/web/aspnet-architecture)
- [Online version](https://docs.microsoft.com/dotnet/architecture/modern-web-apps-azure/)

The eBook covers architectural principles and patterns that this application demonstrates in practice.

### Video Overview

[Steve "ardalis" Smith](https://twitter.com/ardalis) provides [a comprehensive overview of the eShopOnWeb reference application](https://www.youtube.com/watch?v=vRZ8ucGac8M&ab_channel=Ardalis) (recorded October 2020).

### Related Projects

- **[eShopOnContainers](https://github.com/dotnet/eShopOnContainers)** - Microservices-based architecture reference
- The key difference: eShopOnWeb demonstrates a simpler, monolithic approach while eShopOnContainers shows distributed microservices architecture

## Topics Covered (eBook Table of Contents)

The application demonstrates the following architectural concepts and patterns covered in the accompanying eBook:

- Introduction to modern web applications
- Characteristics of Modern Web Applications
- Choosing Between Traditional Web Apps and SPAs
- Architectural Principles (SOLID, DRY, separation of concerns)
- Common Web Application Architectures
- Common Client Side Technologies
- Developing ASP.NET Core MVC Apps
- Working with Data in ASP.NET Core Apps (EF Core, Repository pattern)
- Testing ASP.NET Core MVC Apps
- Development Process for Azure-Hosted ASP.NET Core Apps
- Azure Hosting Recommendations for ASP.NET Core Web Apps

## Getting Started

### Quick Start with In-Memory Database

The fastest way to run the application is using the in-memory database option:

1. Clone or download the repository
2. Open `src/Infrastructure/Dependencies.cs` and ensure in-memory database is enabled
3. Run the Web application:
   ```bash
   cd src/Web
   dotnet run --launch-profile Web
   ```
4. Navigate to `https://localhost:5001/`

### Default Credentials

- **Email:** `demouser@microsoft.com`
- **Password:** `Pass@word1`

### Application Screenshots

**Home page:**

![eShopOnWeb home page screenshot](https://user-images.githubusercontent.com/782127/88414268-92d83a00-cdaa-11ea-9b4c-db67d95be039.png)

### Running with Admin Features

The Web application includes a Blazor WebAssembly-based admin interface. To use the admin functionality:

1. **Start the PublicApi project:**
   ```bash
   cd src/PublicApi
   dotnet run
   ```

2. **Start the Web project (in a separate terminal):**
   ```bash
   cd src/Web
   dotnet run --launch-profile Web
   ```

3. **Access the application:**
   - Web app: `https://localhost:5001/`
   - Admin panel: `https://localhost:5001/admin`

**Tip:** Configure Visual Studio to start multiple projects simultaneously to avoid manual terminal management.

**Note:** When running this way, you'll need to stop the applications manually to rebuild the solution to avoid file locking errors.

## Database Setup

### Option 1: In-Memory Database (Recommended for Quick Start)

Add the following to `src/Web/appsettings.json`:

```json
{
   "UseOnlyInMemoryDatabase": true
}
```

This option requires no additional setup and the database will be seeded with sample data automatically on startup.

### Option 2: SQL Server Database (Persistent Storage)

For a persistent database using SQL Server:

1. **Ensure your connection strings in `appsettings.json` point to your local SQL Server instance**

2. **Install or update Entity Framework Core tools:**
   ```bash
   dotnet tool update --global dotnet-ef
   ```

3. **Navigate to the Web project folder and run migrations:**
   ```bash
   cd src/Web
   dotnet restore
   dotnet tool restore
   ```

4. **Create and seed the databases:**
   ```bash
   # Catalog database (products, shopping cart)
   dotnet ef database update -c catalogcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
   
   # Identity database (user credentials)
   dotnet ef database update -c appidentitydbcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
   ```

5. **Run the application:**
   ```bash
   dotnet run --launch-profile Web
   ```

The application will seed both databases with sample data on first run, including products and a demo user account.

#### Creating New Migrations (Advanced)

If you need to create new migrations after modifying entities:

```bash
# From the Web folder:

# Catalog context migration
dotnet ef migrations add <MigrationName> --context catalogcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj -o Data/Migrations

# Identity context migration
dotnet ef migrations add <MigrationName> --context appidentitydbcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj -o Identity/Migrations
```

## Running with Docker

Docker provides an easy way to run the application with all dependencies configured:

### Using Docker Compose

From the solution root folder (where the `.sln` file is located):

```bash
# Build the Docker images
docker-compose build

# Start the containers
docker-compose up
```

**Access the applications:**
- Web application: `http://localhost:5106`
- Public API: `http://localhost:5200`

**Troubleshooting:** If you experience issues with login, try using a new guest/incognito browser window.

### Using Individual Dockerfiles

You can also build and run each project individually using their respective `Dockerfile`:

```bash
# From the solution root:

# Build Web app image
docker build -f src/Web/Dockerfile -t eshopweb .

# Run Web app container
docker run -p 5106:80 eshopweb
```

Refer to each project's `Dockerfile` for specific build instructions.

## Testing

The solution includes comprehensive test coverage:

- **UnitTests** - Unit tests for business logic
- **IntegrationTests** - Tests with real database integration
- **FunctionalTests** - End-to-end functional tests
- **PublicApiIntegrationTests** - API endpoint tests

Run all tests:
```bash
dotnet test
```

Run specific test project:
```bash
dotnet test tests/UnitTests/UnitTests.csproj
```

## Contributing

Contributions are welcome! This is a reference application, so we aim to keep it focused on demonstrating best practices rather than adding extensive features.

## Community Extensions

We appreciate community contributions! While these aren't maintained by Microsoft, we want to highlight them:

- **[eShopOnWeb VB.NET](https://github.com/VBAndCs/eShopOnWeb_VB.NET)** by Mohammad Hamdy Ghanem - VB.NET port of eShopOnWeb

## Version Information

> ### CURRENT VERSION
> #### The `main` branch is currently running ASP.NET Core 7.0
> #### Older versions are tagged and available in the repository history

## Additional Resources

- **[Official Documentation](https://docs.microsoft.com/aspnet/core/)** - ASP.NET Core documentation
- **[.NET Architecture Guides](https://dotnet.microsoft.com/learn/dotnet/architecture-guides)** - Comprehensive architecture guidance
- **[GitHub Discussions](https://github.com/dotnet-architecture/eShopOnWeb/discussions)** - Community Q&A and discussions
- **[Issues](https://github.com/dotnet-architecture/eShopOnWeb/issues)** - Report bugs or request features

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

This project is maintained by Microsoft and the .NET Foundation community. It's part of the [.NET Architecture guidance](https://dotnet.microsoft.com/learn/dotnet/architecture-guides) initiative.

---

**Questions?** Check the [FAQ](https://github.com/dotnet-architecture/eShopOnWeb/wiki/Frequently-Asked-Questions) or start a [Discussion](https://github.com/dotnet-architecture/eShopOnWeb/discussions).
