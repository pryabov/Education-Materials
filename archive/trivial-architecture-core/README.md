# Console Application with Architecture Sample

Before running the application make sure that the database was created and all migrations were applied.

## Application Functionality

The application is CLI which provides functionality to operate database entities.

Available commands:
```
help
```

```
cars add -n number -o 123 -b Lada -c Black
```

```
cars list
```

## Entity Framework Usage Example

This is a brief example which shows how Entity Framework could be used in your project.

Think about it only like about an example no rules only ideas.

To start using *Sample Project* you need to have on PC [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download)

And extra for our Mastery:
+ [*Microsoft SQL Server* with *SSMS* (SQL Server Management Studio)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
+ [Visual Studio 2019](https://visualstudio.microsoft.com/vs/community/)

Follow steps below:

1. On Visual Studio in Package Manager Console type command:
PowerShell
```
Update-Database -project:TrivialArchitecture.DAL -Verbose
```
2. Run `TrivialArchitecture.UI.Console` project