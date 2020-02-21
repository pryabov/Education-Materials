using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrivialArchitecture.Common;
using TrivialArchitecture.DAL;

namespace TrivialArchitecture.UI.Console.Infrastructure.IoC.Modules
{
	public class DbContextModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			string connectionString = ConfigurationManager.Instance.GetConnectionString();

			var dbContextOptionsBuilder = new DbContextOptionsBuilder<TrivialArchitectureDbContext>()
				.UseSqlServer(connectionString);
		
			builder
				.RegisterType<TrivialArchitectureDbContext>()
				.WithParameter("options", dbContextOptionsBuilder.Options)
				.As<DbContext>()
				.InstancePerLifetimeScope();
		}
	}
}
