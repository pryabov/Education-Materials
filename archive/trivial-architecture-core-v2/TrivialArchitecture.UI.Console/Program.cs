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

		static void Main(string[] args)
		{
			CreateHostBuilder(args).RunConsoleAsync();
		}

		// https://andrewlock.net/exploring-the-new-project-file-program-and-the-generic-host-in-asp-net-core-3/
		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			// Host.CreateDefaultBuilder(args)
			// https://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html
			return new HostBuilder()
				.UseServiceProviderFactory(hostBuilderContext => new AutofacServiceProviderFactory())
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					config.Sources.Clear();

					config.AddJsonFile(
						"appsettings.json", optional: false, reloadOnChange: false);
				})
				.ConfigureServices((HostBuilderContext hostBuilderContext, IServiceCollection services) =>
				{
					// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-3.1
					// services.Configure<ApplicationConfiguration>(hostBuilderContext.Configuration.GetSection("Application"));

					services.AddOptions();

					services.AddHostedService<Worker>();
				})
				.ConfigureContainer((HostBuilderContext hostBuilderContext, ContainerBuilder builder) =>
				{
					builder.RegisterConfiguredModulesFromAssemblyContaining<DbContextModule>(hostBuilderContext.Configuration);
				});
		}
	}
}