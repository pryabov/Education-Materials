using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TrivialArchitecture.UI.Console.Infrastructure.IoC
{
	public static class DependencyResolverContainer
	{
		public static void ConfigureContainerBuilder(
			HostBuilderContext hostBuilderContext,
			ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
		}

		// https://habr.com/ru/post/325194/
		public static ContainerBuilder RegisterConfiguredModulesFromAssemblyContaining<TType>(
			this ContainerBuilder builder,
			IConfiguration configuration)
		{
			if (builder == null)
			{
				throw new ArgumentNullException(nameof(builder));
			}

			if (configuration == null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			var metaBuilder = new ContainerBuilder();

			metaBuilder.RegisterInstance(configuration);
			metaBuilder.RegisterAssemblyTypes(typeof(TType).GetTypeInfo().Assembly)
				.AssignableTo<IModule>()
				.As<IModule>()
				.PropertiesAutowired();

			using (IContainer metaContainer = metaBuilder.Build())
			{
				foreach (IModule module in metaContainer.Resolve<IEnumerable<IModule>>())
				{
					builder.RegisterModule(module);
				}
			}

			return builder;
		}
	}

}
