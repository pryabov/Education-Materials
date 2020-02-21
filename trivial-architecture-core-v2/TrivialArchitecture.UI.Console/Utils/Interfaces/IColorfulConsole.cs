using System.Drawing;

namespace TrivialArchitecture.UI.Console.Utils.Interfaces
{
	public interface IColorfulConsole
	{
		void Write(string text);

		void WriteLine();

		void WriteLine(string text);

		void WriteLineFormatted(string text, Color styledColor, Color defaultColor, params object[] args);

		string ReadLine();
	}
}
