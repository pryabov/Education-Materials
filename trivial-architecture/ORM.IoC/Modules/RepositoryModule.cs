using Autofac;
using ORM.DAL.Core;
using ORM.DAL.Interfaces;
using ORM.DAL.Repositories;

namespace ORM.IoC.Modules
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
				.RegisterType<ORMUow>()
				.As<IORMUow>()
				.InstancePerRequest();
		}
	}
}
