using System.Data.Entity.Migrations;

namespace ORM.DAL.Core.Migrations
{
	public sealed class Configuration : DbMigrationsConfiguration<ORMDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			//AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(ORMDbContext context)
		{
		}
	}
}
