# Integration-Testing-Databases-C#

## This is a test project for the Front-End Technologies May 2024 Course @ SoftUni

### ASP.Net WEB API Integration with SQL Server

---

## About

This project demonstrates how to test the integration of an ASP.Net WEB API with a SQL Server database. It covers various aspects of integration testing using Entity Framework and NUnit.

## Topics Covered

- **SQL Server**: Database management and integration.
- **REST API**: Designing and testing RESTful services.
- **Integration Testing**: Techniques and best practices.
- **Entity Framework**: ORM for database interactions.
- **NUnit Tests**: Writing and executing unit and integration tests for .NET applications.
- **ASP.Net**: Building and testing web applications.

## Project Structure

The project consists of the following key components:

1. **ASP.Net WEB API**: The backend service.
2. **SQL Server Database**: The relational database.
3. **Entity Framework**: For database operations.
4. **NUnit**: For writing and running tests.

### Requirements

- **Visual Studio** with ASP.NET
- **Microsoft SQL Server Management Studio (SSMS)**
- **Docker** (optional, for using a Docker container instead of a local SQL Server instance)
- Local SQL Server instance


### Docker Integration
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

