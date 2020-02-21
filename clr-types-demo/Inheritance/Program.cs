using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var class1 = new Class1();
            var class2 = new Class2();
            var class3 = new Class3();

            int value = 1;

            Console.WriteLine("{0}: {1}", nameof(class1), class1.SomeMethod(value));
            Console.WriteLine("{0}: {1}", nameof(class2), class2.SomeMethod(value));
            Console.WriteLine("{0}: {1}", nameof(class3), class3.SomeMethod(value));
            Console.WriteLine("{0}: {1}", nameof(class1), (class1 as Interface1).SomeMethod(value));
            Console.WriteLine("{0}: {1}", nameof(class1), (class1 as Interface2).SomeMethod(value));
            Console.WriteLine("{0}: {1}", nameof(class3), (class3 as Interface1).SomeMethod(value));
            Console.WriteLine("{0}: {1}", nameof(class3), (class3 as Interface2).SomeMethod(value));
        }
    }
}
