using Microsoft.Extensions.Configuration;

namespace TrivialArchitecture.Common
{
	public class ConfigurationManager
	{
		private static ConfigurationManager instance;

		public static ConfigurationManager Instance => instance ??= new ConfigurationManager();

		public string GetConnectionString()
		{
			ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
			configurationBuilder.Sources.Clear();
			configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
			IConfigurationRoot configurationRoot = configurationBuilder.Build();

			string connectionString = configurationRoot.GetConnectionString("TrivialArchitectureDB");
			return connectionString;
		}
	}
}
