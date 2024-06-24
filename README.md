# ASP.Net WEB API Integration with SQL Server
![image](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![image](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![image](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)
![image](https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
## This is a test project for the Back-End Technologies January 2024 Course @ SoftUni

---

## About
This project demonstrates how to test the integration of an ASP.Net WEB API with a SQL Server database. It covers various aspects of integration testing using Entity Framework and NUnit.

## Technologies Used
- **SQL Server**: Database management and integration.
- **REST API**: Designing and testing RESTful services.
- **Entity Framework**: ORM for database interactions.
- **NUnit Tests**: Writing and executing unit and integration tests for .NET applications.
- **ASP.Net**: Building and testing web applications.

## Project Structure Overview

The application under test is **"Homies"**: A friendly neighbourhood ASP.Net application. The main components of the project are as follows:

1. **Homies.program.cs**: This file contains the main logic of the application, responsible for initializing and running the program.

    - **Areas**: Organizes different functional segments of the application for modular development.
    - **Controllers**: Handles the incoming HTTP requests and responses, managing the flow of data between the models and views.
    - **Data**: Manages the application's data access layer, including database context and migrations.
    - **Models**: Defines the data structures and business logic for the application.
    - **Views**: Contains the user interface components of the application, including HTML templates and Razor views.

2. **Homies.Tests**: This directory contains the integration tests for the application, ensuring that different components work together correctly.

    - **EventControllerTests.cs**: Contains tests for the EventController to verify its functionality and ensure it handles requests as expected.
    - **EventServiceTests.cs**: Includes tests for the EventService, validating the business logic and data handling within the service layer.

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
