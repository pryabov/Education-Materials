using System;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mathematic();

            Compare();
        }

        static void Mathematic()
        {
            int? a = 10;
            int? b = null;

            a--;

            Console.WriteLine($"a: '{a}' - {(a.HasValue ? "is not Null" : "is Null")}");

            a = a + (b ?? 10);

            Console.WriteLine($"a: '{a}' - {(a.HasValue ? "is not Null" : "is Null")}");
        }

        static void Compare()
        {
            int? num1 = 10;
            int? num2 = null;

            if (num1 >= num2)
            {
                Console.WriteLine("num1 is greater than or equal to num2");
            }
            else
            {
                Console.WriteLine("num1 >= num2 returned false (but num1 < num2 also is false)");
            }

            if (num1 < num2)
            {
                Console.WriteLine("num1 is less than num2");
            }
            else
            {
                Console.WriteLine("num1 < num2 returned false (but num1 >= num2 also is false)");
            }

            if (num1 != num2)
            {
                Console.WriteLine("Finally, num1 != num2 returns true!");
            }

            num1 = null;
            if (num1 == num2)
            {
                Console.WriteLine("num1 == num2 returns true when the value of each is null");
            }
        }
    }
}
