using System;
using System.Drawing;
using System.Linq;
using CommandLine;
using TrivialArchitecture.UI.Console.CommandLineVerbs;
using TrivialArchitecture.UI.Console.Utils.Interfaces;

namespace TrivialArchitecture.UI.Console.CommandHandlers
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public class CoreCommandHandler
	{
		private readonly ICommandLineSplitter commandLineSplitter;
		private readonly IColorfulConsole colorfulConsole;
		private readonly CarsCommandHandler carsCommandHandler;

		private enum CommandEntity
		{
			None = 0,
			Car = 1
		}
		
		public CoreCommandHandler(
			ICommandLineSplitter commandLineSplitter,
			IColorfulConsole colorfulConsole,
			CarsCommandHandler carsCommandHandler)
		{
			this.commandLineSplitter = commandLineSplitter;
			this.colorfulConsole = colorfulConsole;
			this.carsCommandHandler = carsCommandHandler;
		}

		public void Handle(string commandLine)
		{
			try
			{
				Program.Logger.Info($"Processing the command \"{commandLine}\"");
				string[] args = commandLineSplitter.Split(commandLine);
				if (args.Length == 0)
				{
					return;
				}

				switch (args.First())
				{
					case "cars":
						carsCommandHandler.ParseCommand(args.Skip(1).ToArray());
						break;

					case "help":
						colorfulConsole.WriteLineFormatted("{0}", Color.Aquamarine, Color.WhiteSmoke, "Information:");
						colorfulConsole.WriteLine("This console provides CLI (Command Line Interface) to operate with entities stored in the Database.");
						colorfulConsole.WriteLine();
						colorfulConsole.WriteLineFormatted("- {0}", Color.GreenYellow, Color.WhiteSmoke, "cars list");
						colorfulConsole.WriteLine("  Shows the full list of cars stored in the Database.");
						break;

					default:
						throw new ArgumentException($"Command \"{args.First()}\" not recognized. Use help command for more information.");
				}
			}
			catch (Exception exception)
			{
				Program.Logger.Error(exception);
				colorfulConsole.WriteLineFormatted("{0} " + exception.Message, Color.Red, Color.WhiteSmoke, "ERROR: ");
			}
		}
	}
}
