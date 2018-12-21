using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace TrivialArchitecture.IoC.Modules
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			Assembly entryAssembly = Assembly.GetExecutingAssembly();

			builder
				.RegisterAssemblyTypes(entryAssembly);
		}
	}
}
