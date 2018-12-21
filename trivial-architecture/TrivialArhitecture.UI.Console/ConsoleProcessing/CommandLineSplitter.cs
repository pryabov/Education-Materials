using System;
using System.Collections.Generic;
using System.Linq;
using TrivialArchitecture.UI.Console.Interfaces;

namespace TrivialArchitecture.UI.Console.ConsoleProcessing
{
    class CommandLineSplitter : ICommandLineSplitter
    {
        public string[] Split(string commandLine)
        {
            List<string> args = new List<string>();

            int lastIndex = -1;
            bool quotesFlag = false;

            for (int index = 0; index < commandLine.Length; ++index)
            {
                var symbol = commandLine[index];
                if (symbol == '"')
                {
                    quotesFlag = !quotesFlag;
                    continue;
                }

                if (quotesFlag || symbol != ' ')
                    continue;

                var argument = GetArgument(commandLine, lastIndex + 1, index);
                lastIndex = index;

                args.Add(argument);
            }

            args.Add(GetArgument(commandLine, lastIndex + 1, commandLine.Length));
            return args.Where(arg => !String.IsNullOrWhiteSpace(arg)).ToArray();
        }

        private string GetArgument(string commandLine, int startIndex, int endIndex)
        {
            string argument = commandLine.Substring(startIndex, endIndex - startIndex);
            return argument.TrimStart('"').TrimEnd('"');
        }
    }
}
