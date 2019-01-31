using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Class2 : Interface1
    {
        public int SomeMethod(int value)
        {
            return (value + 1) * 20;
        }
    }
}
