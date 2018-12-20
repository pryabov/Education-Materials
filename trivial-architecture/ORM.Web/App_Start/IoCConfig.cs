using System.Web.Http;
using System.Web.Mvc;
using ORM.IoC;

namespace ORM.Web
{
	public static class IoCConfig
	{
		public static void ConfigureIoC()
		{
			DependencyResolverContainer container = new DependencyResolverContainer();

			DependencyResolver.SetResolver(container.MvcDependencyResolver);
			GlobalConfiguration.Configuration.DependencyResolver = container.WebApiDependencyResolver;
		}
	}
}