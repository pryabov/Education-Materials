using System;
using System.Collections;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //var someClass = new SomeClassA();

            //foreach(var item in someClass)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();

            var someOtherClass = new SomeOtherClass();

            foreach (var item in someOtherClass)
            {
                Console.WriteLine(item);
            }
        }
    }


    class SomeClassA : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return new SomeClass();
        }
    }

    class SomeClass : IEnumerator
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        int position = -1;

        public object Current{
            get
            {
                try
                {
                    return array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }

    class SomeOtherClass : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for(int i = 10; i > 0; i--)
            {
                if (i == 5)
                {
                    yield break;
                }

                yield return i;
            }
        }
    }
}
