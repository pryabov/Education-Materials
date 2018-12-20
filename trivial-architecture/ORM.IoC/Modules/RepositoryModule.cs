using Autofac;
using TrivialArchitecture.DAL;
using TrivialArchitecture.DAL.Interfaces;
using TrivialArchitecture.DAL.Repositories;

namespace TrivialArchitecture.IoC.Modules
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
				.InstancePerRequest();

			// Register generic repositories.
			builder
				.RegisterGeneric(typeof(BaseRepository<>))
				.AsImplementedInterfaces()
				.InstancePerRequest();

			// Register unit of work.
			builder
				.RegisterType<TrivialArchitectureUow>()
				.As<ITrivialArchitectureUow>()
				.InstancePerRequest();
		}
	}
}
