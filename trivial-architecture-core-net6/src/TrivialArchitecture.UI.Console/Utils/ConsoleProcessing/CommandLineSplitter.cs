using System.Collections.Generic;
using System.Linq;
using TrivialArchitecture.UI.Console.Utils.Interfaces;

namespace TrivialArchitecture.UI.Console.Utils.ConsoleProcessing
{
	public class CommandLineSplitter : ICommandLineSplitter
	{
		public string[] Split(string commandLine)
		{
			List<string> args = new List<string>();

			int lastIndex = -1;
			bool quotesFlag = false;

			for (int index = 0; index < commandLine.Length; ++index)
			{
				char symbol = commandLine[index];
				if (symbol == '"')
				{
					quotesFlag = !quotesFlag;
					continue;
				}

				if (quotesFlag || symbol != ' ')
				{
					continue;
				}

				string argument = GetArgument(commandLine, lastIndex + 1, index);
				lastIndex = index;

				args.Add(argument);
			}

			args.Add(GetArgument(commandLine, lastIndex + 1, commandLine.Length));
			return args.Where(arg => !string.IsNullOrWhiteSpace(arg)).ToArray();
		}

		private string GetArgument(string commandLine, int startIndex, int endIndex)
		{
			string argument = commandLine.Substring(startIndex, endIndex - startIndex);
			return argument.TrimStart('"').TrimEnd('"');
		}
	}
}
