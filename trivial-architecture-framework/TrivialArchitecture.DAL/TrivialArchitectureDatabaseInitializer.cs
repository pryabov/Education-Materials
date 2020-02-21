using System.Data.Entity;
using TrivialArchitecture.DAL.Migrations;

namespace TrivialArchitecture.DAL
{
	public class OrmDatabaseInitializer : MigrateDatabaseToLatestVersion<TrivialArchitectureDbContext, Configuration>
	{

	}

	//public class ORMDatabaseInitializer : DropCreateDatabaseAlways<TrivialArchitectureDbContext>
	//{
	//	protected override void Seed(TrivialArchitectureDbContext context)
	//	{
	//		Tag tag = new Tag
	//			{
	//				Name = "Test Tag"
	//			};
	//		context.Tags.Add(tag);
	//		context.SaveChanges();

	//		base.Seed(context);
	//	}
	//}
}
