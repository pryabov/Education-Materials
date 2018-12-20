using System.Web.Http;
using ORM.Web.Helpers;

namespace ORM.Web.App_Start
{
	public static class GlobalConfig
	{
		public static void CustomizeConfig(HttpConfiguration config)
		{
			// Remove XML formatters. This means when we visit an endpoint from a browser,
			// Instead of returning XML, it will return JSON.
			// More information from Dave Ward: http://jpapa.me/P4vdx6
			config.Formatters.Remove(config.Formatters.XmlFormatter);

			config.Formatters.Remove(config.Formatters.JsonFormatter);
			config.Formatters.Insert(0, CustomJsonFormatter.ApplicationJsonFormatter);
		}
	}
}