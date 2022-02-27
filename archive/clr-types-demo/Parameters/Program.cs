using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            var someClass = new SomeClass();

            int intValue = 5;

            someClass.SomeMethod2(intValue);
            Console.WriteLine(intValue);

            someClass.SomeMethod2(ref intValue);
            Console.WriteLine(intValue);

            someClass.SomeMethod3(out int newIntValue);
            Console.WriteLine(newIntValue);
        }
    }

    class SomeClass
    {
        public void SomeMethod(in string value)
        {
        }
        public void SomeMethod2(int value)
        {
            value = 2;
        }
        public void SomeMethod2(ref int value)
        {
            value = 2;
        }
        public void SomeMethod3(out int value)
        {
            value = 0;
        }
    }
}
