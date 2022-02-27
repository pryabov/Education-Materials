using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using TrivialArchitecture.UI.Console.Infrastructure.IoC;
using TrivialArchitecture.UI.Console.Infrastructure.IoC.Modules;

namespace TrivialArchitecture.UI.Console
{
	static class Program
	{
		public static readonly Logger Logger = LogManager.GetLogger("storageUILogger");

		static async Task Main(string[] args)
		{
			await CreateHostBuilder(args).RunConsoleAsync();
		}

		private static IHostBuilder CreateHostBuilder(string[] args) =>
			// Host.CreateDefaultBuilder(args)
			// https://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html
			new HostBuilder()
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					config.Sources.Clear();

					config.AddJsonFile(
						"appsettings.json", optional: false, reloadOnChange: false);
				})
				.ConfigureServices((hostBuilderContext, services) =>
				{
					// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0
					services.AddOptions();

					services.AddHostedService<Worker>();
				})
				.ConfigureContainer((HostBuilderContext hostBuilderContext, ContainerBuilder builder) =>
				{
					builder.RegisterConfiguredModulesFromAssemblyContaining<DbContextModule>(hostBuilderContext.Configuration);
				});
	}
}