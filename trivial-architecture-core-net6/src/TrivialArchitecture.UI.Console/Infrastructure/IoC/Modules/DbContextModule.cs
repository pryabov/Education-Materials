using Autofac;
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

			string pathToDatabaseFile = Сonfiguration.GetConnectionString("TrivialArchitectureFileStorage");

			builder
				.RegisterType<TrivialArchitectureDbContext>()
				.WithParameter("pathToDatabaseFile", pathToDatabaseFile)
				.As<TrivialArchitectureDbContext>()
				.InstancePerLifetimeScope();
		}
	}
}
