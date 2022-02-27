using Autofac;
using System.Reflection;

namespace TrivialArchitecture.UI.Console.Infrastructure.IoC.Modules
{
	public class ApplicationModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			Assembly entryAssembly = Assembly.GetEntryAssembly();

			builder
				.RegisterAssemblyTypes(entryAssembly)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder
				.RegisterAssemblyTypes(entryAssembly)
				.InstancePerLifetimeScope();
		}
	}
}
