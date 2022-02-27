using System.Data.Entity;
using TrivialArchitecture.DAL.Entities.Books;
using TrivialArchitecture.DAL.Entities.Cars;

namespace TrivialArchitecture.DAL
{
	public class TrivialArchitectureDbContext : DbContext
	{
		public DbSet<CarDriver> CarDrivers { get; set; }

		public DbSet<Car> Cars { get; set; }

		public DbSet<Tag> Tags { get; set; }

		public TrivialArchitectureDbContext()
			: base("TrivialArchitectureDB")
		{
		}
	}
}
