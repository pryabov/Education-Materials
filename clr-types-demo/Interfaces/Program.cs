using Interfaces.Interfaces;
using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<ISomeInterface>();
            list.Add(new SomeClass());
            list.Add(new SomeStruct());

            foreach(var item in list)
            {
                item.SomeMethod();
            }
        }
    }
}
