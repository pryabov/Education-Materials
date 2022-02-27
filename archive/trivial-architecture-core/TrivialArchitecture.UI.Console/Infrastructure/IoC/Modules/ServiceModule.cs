using Autofac;
using TrivialArchitecture.BusinessLogic;

namespace TrivialArchitecture.UI.Console.Infrastructure.IoC.Modules
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder
				.RegisterAssemblyTypes(typeof(BaseService).Assembly)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}
