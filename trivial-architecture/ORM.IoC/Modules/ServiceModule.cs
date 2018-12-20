using Autofac;
using ORM.BusinessLogic.Core;

namespace ORM.IoC.Modules
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder
				.RegisterAssemblyTypes(typeof(BaseService).Assembly)
				.AsImplementedInterfaces()
				.InstancePerRequest();
		}
	}
}
