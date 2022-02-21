using System.Data.Entity.Migrations;

namespace TrivialArchitecture.DAL.Migrations
{
	public sealed class Configuration : DbMigrationsConfiguration<TrivialArchitectureDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			//AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(TrivialArchitectureDbContext context)
		{
		}
	}
}
