using Interfaces.Interfaces;
using System;

namespace Interfaces
{
    class SomeClass : ISomeInterface
    {
        public void SomeMethod()
        {
            Console.WriteLine("SomeClass.SomeMethod");
        }

        void SomeOtherMethod()
        {

        }
    }
}
