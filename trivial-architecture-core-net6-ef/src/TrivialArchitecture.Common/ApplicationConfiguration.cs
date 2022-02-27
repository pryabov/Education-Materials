using TrivialArchitecture.Common.Interfaces;

namespace TrivialArchitecture.Common
{
	public class ApplicationConfiguration: IApplicationConfiguration
	{
		public string ConnectionString { get; set; }
	}
}
