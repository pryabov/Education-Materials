using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrivialArchitecture.DAL.Entities.Books;
using TrivialArchitecture.DAL.Entities.Cars;

namespace TrivialArchitecture.DAL
{
	public class TrivialArchitectureDbContext : DbContext
	{
		public DbSet<CarDriver> CarDrivers { get; set; }

		public DbSet<Car> Cars { get; set; }

		public DbSet<Tag> Tags { get; set; }

		public DbSet<Book> Books { get; set; }

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

		// public TrivialArchitectureDbContext() : base()
		// {
		// }

		public TrivialArchitectureDbContext(DbContextOptions<TrivialArchitectureDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		// {
		// 	base.OnConfiguring(optionsBuilder);
		//
		// 	optionsBuilder
		// 		.UseSqlServer(
		// 			@"Data Source=.\;Initial Catalog=TrivialArchitecture;Integrated Security=true"
		// 			, providerOptions => providerOptions.CommandTimeout(60))
		// 		.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		// }
	}
}
