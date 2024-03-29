# Console Application with Architecture Sample (.NET 6 + EF Core)

Before running the application make sure that the database was created and all migrations have been applied.

## Application Functionality

The application is CLI which provides functionality to operate database entities.

Available commands:

```cmd
help
```

```cmd
cars add -n number -o 123 -b Lada -c Black
```

```cmd
cars list
```

## Example Usage

This is a brief example which shows how Entity Framework Core could be used in your project.

Think about it only like about an example there is no rules only ideas.

### Software pre-requirements

To start using *Sample Project* for education purposes you need to have on PC:

+ [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
+ [*Microsoft SQL Server 2019 Developer Edition* or higher](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
+ [*SSMS* (SQL Server Management Studio) can be helpful for you as well](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
+ [Visual Studio 2022 Community](https://visualstudio.microsoft.com/vs/) as IDE. There can be any other IDE for .NET which you are prefer.

### Steps for the first run

This example will be based on [cli tools for Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) to apply migrations to Database as tool supported on many platforms and recomended by Microsoft.
But if you like to work inside Visual Studio IDE you still can use [the Package Manager Console (PMC) tools for Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/cli/powershell).


1. In cmd type use command to create and updae database
```cmd
dotnet ef database update --project src\TrivialArchitecture.DAL\TrivialArchitecture.DAL.csproj --startup-project src\TrivialArchitecture.UI.Console\TrivialArchitecture.UI.Console.csproj
```

2. Run `TrivialArchitecture.UI.Console` project

### HOW-TO

#### EF cli tool installation

```cmd
dotnet tool update --global dotnet-ef
```

#### Initial Migration Creation

For creating initial migration was used cmd command below.

```cmd
dotnet ef migrations add InitialCreate --project src\TrivialArchitecture.DAL\TrivialArchitecture.DAL.csproj --startup-project src\TrivialArchitecture.UI.Console\TrivialArchitecture.UI.Console.csproj
```
