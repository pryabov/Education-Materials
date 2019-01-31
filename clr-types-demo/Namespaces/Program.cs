using Namespaces.Class1;
using Namespaces.Class2;

using Class2Action = Namespaces.Class2.Action;

namespace Namespaces
{
    class Program
    {
        static void Main(string[] args)
        {

            var class1 = new SomeClass1();

            class1.Action = new Class1.Action();

            var class2 = new SomeClass2();

            class2.Action = new Class2Action();
        }
    }
}
