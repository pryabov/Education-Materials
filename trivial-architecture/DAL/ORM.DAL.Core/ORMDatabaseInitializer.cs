using System.Data.Entity;
using ORM.DAL.Core.Migrations;

namespace ORM.DAL.Core
{
	public class ORMDatabaseInitializer : MigrateDatabaseToLatestVersion<ORMDbContext, Configuration>
	{

	}

	//public class ORMDatabaseInitializer : DropCreateDatabaseAlways<ORMDbContext>
	//{
	//	protected override void Seed(ORMDbContext context)
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
