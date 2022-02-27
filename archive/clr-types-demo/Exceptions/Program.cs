using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var someClass = new SomeClass();

            //try
            //{
            //    someClass.SomeMethod();
            //}
            //catch(InvalidOperationException ex)
            //{
            //    Console.WriteLine($"1: {ex.Message}");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine($"2: {ex.Message}");
            //}

            Console.WriteLine(someClass.SomeOtherMethod());
        }
    }

    class SomeClass
    {
        public void SomeMethod()
        {
            throw new ArgumentOutOfRangeException();
        }

        public int SomeOtherMethod()
        {
            try
            {
                return 5;
            }
            catch(Exception x)
            {
                return 0;
            }
            finally
            {
                SomePrivateMethod();
            }
        }

        private int SomePrivateMethod()
        {
            return 6;
        }
    }
}
