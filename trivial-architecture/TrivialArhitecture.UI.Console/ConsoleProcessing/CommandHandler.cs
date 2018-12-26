using System;
using System.Drawing;
using System.Linq;
using CommandLine;
using TrivialArchitecture.UI.Console.CommandLineVerbs;
using TrivialArchitecture.UI.Console.Interfaces;

namespace TrivialArchitecture.UI.Console.ConsoleProcessing
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public class CommandHandler
	{
		private readonly ICommandLineSplitter commandLineSplitter;
		private readonly IColorfulConsole colorfulConsole;

		private enum CommandEntity
		{
			NotSpecified = 0,
			Car = 1
		}
		
		public CommandHandler(ICommandLineSplitter commandLineSplitter, IColorfulConsole colorfulConsole)
		{
			this.commandLineSplitter = commandLineSplitter;
			this.colorfulConsole = colorfulConsole;
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
						ParseCommand(args.Skip(1).ToArray(), CommandEntity.Car);
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

		private void ParseCommand(string[] args, CommandEntity commandEntity = CommandEntity.NotSpecified)
		{
			switch (commandEntity)
			{
				case CommandEntity.Car:
					Parser.Default.ParseArguments<ListCommandLineVerb>(args)
						.WithParsed<ListCommandLineVerb>(opts => PrintEntitiesList(commandEntity));
					break;
			}
		}

		private void PrintEntitiesList(CommandEntity commandEntity)
		{

		}
	}
}
