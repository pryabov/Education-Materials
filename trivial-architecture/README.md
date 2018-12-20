# Entity Framework

## Code First Usage Example

This is a brief example which shows how Entity Framework could be used in your project.

Think about it only like about an example no rules only ideas.

To start using *Sample Project* you need to have on PC:

+ *Microsoft SQL Server 2016* or higher with *SSMS* (SQL Server Management Studio)
+ Visual Studio 2017

Follow steps below:

1. In *SSMS* create Database `ORM`. Current system user should be an owner
2. On Visual Studio in Package Manager Console type command:
```powershell
Update-Database -project:ORM.DAL.Core -Force -Verbose
```
3. Run ORM.Web project
