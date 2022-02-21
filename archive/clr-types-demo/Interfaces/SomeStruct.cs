using Interfaces.Interfaces;
using System;

namespace Interfaces
{
    struct SomeStruct : ISomeInterface
    {
        public void SomeMethod()
        {
            Console.WriteLine("SomeStruct.SomeMethod");
        }
    }
}
