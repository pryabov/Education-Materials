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

## Entity Framework (Code First) Usage Example

This is a brief example which shows how Entity Framework could be used in your project.

Think about it only like about an example no rules only ideas.

To start using *Sample Project* you need to have on PC:

+ *Microsoft SQL Server 2016* or higher with *SSMS* (SQL Server Management Studio)
+ Visual Studio 2019

Follow steps below:

1. In *SSMS* create Database `TrivialArchitecture`. Current system user should be an owner
2. On Visual Studio in Package Manager Console type command:
PowerShell
```
Update-Database -project:TrivialArchitecture.DAL -Force -Verbose
```
3. Run `TrivialArchitecture.UI.Console` project