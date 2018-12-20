using System.Drawing;
using TrivialArchitecture.UI.Console.Interfaces;

namespace TrivialArchitecture.UI.Console
{
    public class ColorfulConsole : IColorfulConsole
    {
        public string ReadLine()
        {
            return ColorfulC.ReadLine();
        }

        public void Write(string text)
        {
            ColorfulC.Write(text);
        }

        public void WriteLine()
        {
            ColorfulC.WriteLine();
        }

        public void WriteLine(string text)
        {
            ColorfulC.WriteLine(text);
        }

        public void WriteLineFormatted(string text, Color styledColor, Color defaultColor, params object[] args)
        {
            ColorfulC.WriteLineFormatted(text, styledColor, defaultColor, args);
        }
    }
}
