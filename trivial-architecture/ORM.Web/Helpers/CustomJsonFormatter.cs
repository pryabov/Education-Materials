using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ORM.Web.Helpers
{
	public class CustomJsonFormatter : JsonMediaTypeFormatter
	{
		static CustomJsonFormatter()
		{
			ApplicationJsonFormatter = GetApplicationFormatter();
		}

		public static JsonMediaTypeFormatter ApplicationJsonFormatter { get; private set; }

		private static JsonMediaTypeFormatter GetApplicationFormatter()
		{
			CustomJsonFormatter result = new CustomJsonFormatter();

			result.SerializerSettings.Converters.Add(new StringEnumConverter());
			result.SerializerSettings.Formatting = Formatting.Indented;
			result.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			return result;
		}
	}
}