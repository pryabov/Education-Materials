using System;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace ORM.IoC.Modules
{
	public class ControllerModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			Assembly entryAssembly = GetWebEntryAssembly();

			// Register MVC controllers.
			builder
				.RegisterControllers(entryAssembly)
				.InstancePerRequest();

			// Register Web API controllers.
			builder
				.RegisterApiControllers(entryAssembly)
				.InstancePerRequest();
		}

		private static Assembly GetWebEntryAssembly()
		{
			HttpApplication proxyApplicationInstance = HttpContext.Current.ApplicationInstance;
			Type proxyApplicationInstanceType = proxyApplicationInstance.GetType();
			Type baseApplicationInstanceType = proxyApplicationInstanceType.BaseType;

			return baseApplicationInstanceType?.Assembly;
		}
	}
}
