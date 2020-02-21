using System;

namespace StaticCtor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"class static value: {SomeClass.y}");

            var someClass = new SomeClass();

            someClass.x = 123;

            Console.WriteLine($"class value: {someClass.x}");
            Console.WriteLine($"class static value: {SomeClass.y}");

            Console.WriteLine($"struct static value: {SomeValue.y}");
            var someValue = new SomeValue();

            Console.WriteLine($"struct value: {someValue.x}");
            Console.WriteLine($"struct static value: {SomeValue.y}");

            var someValueArray = new SomeValue[10];

            someValueArray[0].x = 123;

            Console.WriteLine($"array item value: {someValueArray[0].x}");
        }
    }

    class SomeClass
    {
        public static int y;
        public int x;

        static SomeClass()
        {
            y = 5;
            Console.WriteLine("static contructor of SomeClass");
        }
    }

    struct SomeValue
    {
        public static int y;

        static SomeValue()
        {
            y = 5;
            Console.WriteLine("static contructor of SomeValue");
        }

        public int x;
    }
}
