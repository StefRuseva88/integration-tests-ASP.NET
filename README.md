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


### Using Docker Instead of SSMS

#### Steps

 **Pull the SQL Server Docker Image**
   ```sh
   docker pull mcr.microsoft.com/mssql/server
   
# Run a SQL Server Container

```sh
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server

