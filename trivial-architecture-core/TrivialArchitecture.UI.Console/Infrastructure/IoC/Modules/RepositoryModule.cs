using Autofac;
using TrivialArchitecture.DAL;
using TrivialArchitecture.DAL.Repositories;
using TrivialArchitecture.DAL.Repositories.Interfaces;

namespace TrivialArchitecture.UI.Console.Infrastructure.IoC.Modules
{
	public class RepositoryModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			// Register non-generic repositories.
			builder
				.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
				.AsClosedTypesOf(typeof(IRepository<>))
				.InstancePerLifetimeScope();

			// Register generic repositories.
			builder
				.RegisterGeneric(typeof(BaseRepository<>))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			// Register unit of work.
			builder
				.RegisterType<TrivialArchitectureUow>()
				.As<ITrivialArchitectureUow>()
				.InstancePerLifetimeScope();
		}
	}
}
