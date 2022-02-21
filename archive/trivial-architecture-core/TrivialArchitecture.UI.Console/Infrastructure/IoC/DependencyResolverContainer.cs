using Autofac;
using System.Reflection;

namespace TrivialArchitecture.UI.Console.Infrastructure.IoC
{
	public class DependencyResolverContainer
	{
		public DependencyResolverContainer()
		{
			Container = CreateContainer();
		}

		public IContainer Container { get; }

		private static IContainer CreateContainer()
		{
			ContainerBuilder containerBuilder = new ContainerBuilder();

			containerBuilder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

			return containerBuilder.Build();
		}
	}
}
