using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TrivialArchitecture.DAL.Base;
using TrivialArchitecture.DAL.Base.Enums;
using TrivialArchitecture.DAL.Entities.Cars;

namespace TrivialArchitecture.DAL
{
	public class TrivialArchitectureDbContext: DbContext
	{
		public DbSet<CarDriver> CarDrivers { get; set; }

		public DbSet<Car> Cars { get; set; }

		private readonly string pathToDatabaseFile;

		public TrivialArchitectureDbContext(string pathToDatabaseFile)
		{
			this.pathToDatabaseFile = pathToDatabaseFile;
		}
	}
}
