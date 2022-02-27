using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TrivialArchitecture.DAL.Base;
using TrivialArchitecture.DAL.Entities.Cars;
using TrivialArchitecture.DAL.Interfaces;

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

		// https://github.com/dotnet/efcore/issues/9662
		public override int SaveChanges()
		{
			IEnumerable<object> entities = ChangeTracker.Entries()
				.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
				.Select(e => e.Entity);

			foreach (object entity in entities)
			{
				var validationContext = new ValidationContext(entity);
				Validator.ValidateObject(entity, validationContext);
			}

			return base.SaveChanges();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
