using System.Drawing;
using TrivialArchitecture.UI.Console.Utils.Interfaces;

namespace TrivialArchitecture.UI.Console.Utils.ConsoleProcessing
{
	public class ColorfulConsole : IColorfulConsole
	{
		public string ReadLine()
		{
			return Colorful.Console.ReadLine();
		}

		public void Write(string text)
		{
			Colorful.Console.Write(text);
		}

		public void WriteLine()
		{
			Colorful.Console.WriteLine();
		}

		public void WriteLine(string text)
		{
			Colorful.Console.WriteLine(text);
		}

		public void WriteLineFormatted(string text, Color styledColor, Color defaultColor, params object[] args)
		{
			Colorful.Console.WriteLineFormatted(text, styledColor, defaultColor, args);
		}
	}
}
