using System;

namespace EnumsValues
{
    [Flags]
    enum SomeEnum
    {
        SomeValue1,
        SomeValue2,
        SomeValue4,
        SomeValue5
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{"".IsNullOrEmpty()}");
            Console.WriteLine($"{"123".IsNullOrEmpty()}");
        }

        static int SomeMethod(string value2, string value = "", int i = 0, decimal d = 0.0M)
        {
            return value.Length + i + (int) d;
        }
    }

    static class Extention
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
