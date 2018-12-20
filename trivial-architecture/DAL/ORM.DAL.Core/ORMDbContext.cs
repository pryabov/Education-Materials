using System.Data.Entity;
using ORM.DAL.Models.Entities;

namespace ORM.DAL.Core
{
	public class ORMDbContext : DbContext
	{
		public DbSet<CarDriver> CarDrivers { get; set; }

		public DbSet<Car> Cars { get; set; }

		public DbSet<Tag> Tags { get; set; }

		public ORMDbContext()
			: base("ORM")
		{
		}
	}
}
