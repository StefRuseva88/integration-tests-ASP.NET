# ASP.Net WEB API Integration with SQL Server

## This is a test project for the Front-End Technologies May 2024 Course @ SoftUni

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

### Updating the Database
Apply Migrations
In the Package Manager Console within Visual Studio, run Update-Database to apply migrations to your database.

### Verifying Database Creation
Locate the Database
In your SQL client, expand the 'Databases' folder. You should see a list of all databases on the server.

### Check for the New Database
Look for the database name specified in your ASP.NET project's connection string. If the Update-Database command executed successfully, your database should be listed here.
### Interacting with the Application's Front End and Observing Database Changes
Access the Front End
Open the front end of your application, a web page in your browser.

### User Registration
Use the user authentication features provided by ASP.NET Identity to register a new user and log in to the application.

### Verify Account Creation in Database
Refresh the database view, navigate to the users table (often named AspNetUsers), and verify that your new user account is listed.

### Proceed with CRUD Operations
Once logged in, perform CRUD operations as an authenticated user, reflecting a more realistic use-case scenario.

### Usage
This project provides a simple example of how to:

Set up a SQL Server database and connect it to an ASP.Net WEB API.
Use Entity Framework for database operations.
Write integration tests using NUnit to ensure that the API interacts correctly with the database.
### Contributing
Contributions are welcome! Please submit a pull request or open an issue to discuss your changes.

### License
This project is licensed under the [MIT License](LICENSE). See the [LICENSE](LICENSE) file for details.
