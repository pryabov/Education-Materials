using CommandLine;
using TrivialArchitecture.DAL.Entities.Cars.Enums;

namespace TrivialArchitecture.UI.Console.CommandLineVerbs
{
	[Verb("add", HelpText = "Downloading a file from the storage.")]
	class AddCarCommandLineVerb
	{
		[Option('n', "number", Required = true, HelpText = "Set output to verbose messages.")]
		public string Number { get; set; }

		[Option('o', "odometer", Required = true, HelpText = "Set output to verbose messages.")]
		public double Odometer { get; set; }

		[Option('b', "brand", Required = true, HelpText = "Set output to verbose messages.")]
		public CarBrand Brand { get; set; }

		[Option('c', "color", Required = true, HelpText = "Set output to verbose messages.")]
		public CarColor Color { get; set; }
	}
}
