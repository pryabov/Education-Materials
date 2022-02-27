using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrivialArchitecture.DAL;

namespace TrivialArchitecture.UI.Console.Infrastructure.IoC.Modules
{
	public class DbContextModule : Module
	{
		public IConfiguration Сonfiguration { get; set; }

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			string connectionString = Сonfiguration.GetConnectionString("TrivialArchitectureDB");

			var dbContextOptionsBuilder = new DbContextOptionsBuilder<TrivialArchitectureDbContext>()
				.UseSqlServer(connectionString);
		
			builder
				.RegisterType<TrivialArchitectureDbContext>()
				.WithParameter("options", dbContextOptionsBuilder.Options)
				.As<DbContext>()
				.As<TrivialArchitectureDbContext>()
				.InstancePerLifetimeScope();
		}
	}
}
