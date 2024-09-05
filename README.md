# ASP.NET WEB API Integration with SQL Server
[![C#](https://img.shields.io/badge/Made%20with-C%23-239120.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-5C2D91.svg)](https://dotnet.microsoft.com/)
[![MS SQL Server](https://img.shields.io/badge/Database-MS%20SQL%20Server-CC2927.svg)](https://www.microsoft.com/en-us/sql-server)
[![Docker](https://img.shields.io/badge/Powered%20by-Docker-2496ED.svg)](https://www.docker.com/)
[![NUnit](https://img.shields.io/badge/tested%20with-NUnit-22B2B0.svg)](https://nunit.org/)

## This is a test project for the **Back-End Technologies** January 2024 Course @ SoftUni

---

## Project Overview
This project demonstrates how to test the integration of an ASP.Net WEB API with a SQL Server database. It covers various aspects of integration testing using Entity Framework and NUnit.

## Tools and Technologies
- **SQL Server**: Used for database management and integration.
- **REST API**: For creating and testing RESTful services.
- **Entity Framework**: ORM used for managing database interactions.
- **NUnit Tests**: Framework for writing unit and integration tests for .NET.
- **ASP.Net**: For building and testing web applications.

## Project Overview

The project under test is called **"Homies"**, an ASP.NET application. The key components include:

1. **Homies.program.cs**: This file initializes and runs the application.

    - **Areas**: Groups different functional segments of the application for modularity.
    - **Controllers**: Manages HTTP requests and responses, coordinating data flow between models and views.
    - **Data**: Contains the data access layer, including the database context and migrations.
    - **Models**: Defines the application's data structures and business logic.
    - **Views**: Contains the UI elements, including HTML templates and Razor views.

2. **Homies.Tests**: This directory includes integration tests to verify that various components function correctly together.

    - **EventControllerTests.cs**: Contains tests for the Controller to verify correct request handling.
    - **EventServiceTests.cs**: Tests the Service, ensuring business logic and data processing work as expected.

## Requirements
- **Visual Studio** with ASP.NET
- **Microsoft SQL Server Management Studio (SSMS)**
- **Docker** (optional, for using a Docker container instead of a local SQL Server instance)
- Local SQL Server instance


## Docker Integration
You can also run the SQL Server using a Docker image, which simplifies the setup and ensures consistency across different environments. To set up SQL Server with Docker, follow these steps:

1. **Pull the SQL Server Docker image**:

    ```bash
    docker pull mcr.microsoft.com/mssql/server
    ```

2. **Run the Docker container**:

    ```bash
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Your_password123' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server
    ```

3. **Connect to the SQL Server**:

    - Use the connection string: `Server=localhost,1433;Database=YourDatabase;User Id=sa;Password=Your_password123;`
    - Replace `YourDatabase` with the name of your database.

For more information on using Docker with SQL Server, you can refer to the [official Docker documentation](https://hub.docker.com/_/microsoft-mssql-server) and the [SQL Server on Docker guide](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-docker-container-deployment).

## Updating the Database
Apply Migrations
In the Package Manager Console within Visual Studio, run ``Update-Database`` to apply migrations to your database.

## Verifying Database Creation
Locate the Database
In your SQL client, expand the 'Databases' folder. You should see a list of all databases on the server.
Look for the database name specified in your ASP.NET project's connection string. If the ``Update-Database`` command executed successfully, your database should be listed there.

## User Registration
Use the user authentication features provided by ASP.NET Identity to register a new user and log in to the application.

## Verify Account Creation in Database
Refresh the database view, navigate to the users table (often named AspNetUsers), and verify that your new user account is listed.

## Proceed with CRUD Operations
Once logged in, perform CRUD operations as an authenticated user, reflecting a more realistic use-case scenario.

## Usage
This project provides an example of how to:

Set up a SQL Server database and connect it to an ASP.Net WEB API.
Use Entity Framework for database operations.
Write integration tests using NUnit to ensure that the API interacts correctly with the database.
### Contributing
Contributions are welcome! Please submit a pull request or open an issue to discuss your changes.

## License
This project is licensed under the [MIT License](LICENSE). See the [LICENSE](LICENSE) file for details.

---
### Happy Testing! 🚀
