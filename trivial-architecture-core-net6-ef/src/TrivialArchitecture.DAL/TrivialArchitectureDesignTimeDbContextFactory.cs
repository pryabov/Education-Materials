using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TrivialArchitecture.DAL
{
	// https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#from-a-design-time-factory
	//public class TrivialArchitectureDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TrivialArchitectureDbContext>
	//{
	//	public TrivialArchitectureDbContext CreateDbContext(string[] args)
	//	{
	//		DbContextOptionsBuilder<TrivialArchitectureDbContext> builder = new DbContextOptionsBuilder<TrivialArchitectureDbContext>();
	//		builder.UseSqlServer("Data Source =.\\; Initial Catalog = TrivialArchitecture; Integrated Security = true");
	//		return new TrivialArchitectureDbContext(builder.Options);
	//	}
	//}
}
