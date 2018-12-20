using System.Data.Entity;
using Autofac;
using ORM.DAL.Core;

namespace ORM.IoC.Modules
{
	public class DbContextModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder
				.RegisterType<ORMDbContext>()
				.As<DbContext>()
				.InstancePerRequest();
		}
	}
}
