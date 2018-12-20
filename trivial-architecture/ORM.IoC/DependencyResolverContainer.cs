using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace TrivialArchitecture.IoC
{
	public class DependencyResolverContainer
	{
		public DependencyResolverContainer()
		{
			IContainer container = CreateContainer();

			MvcDependencyResolver = new AutofacDependencyResolver(container);
			WebApiDependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

		public System.Web.Mvc.IDependencyResolver MvcDependencyResolver { get; }

		public System.Web.Http.Dependencies.IDependencyResolver WebApiDependencyResolver { get; }

		private static IContainer CreateContainer()
		{
			ContainerBuilder containerBuilder = new ContainerBuilder();

			containerBuilder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

			return containerBuilder.Build();
		}
	}
}
