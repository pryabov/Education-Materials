using System;

namespace ValueTypes
{
    class Boxed_Unboxed
    {
        public void Test1()
        {
            int x = 5;
            object o = x;
        }

        public void Test2()
        {
            Point p;

            p.x = 1;
            p.y = 1;

            object o = p;

            Console.WriteLine("{0}, {1}", p.ToString(), o);

            p = (Point)o;

            p.x = 2;

            Console.WriteLine("{0}, {1}", p.ToString(), o);

            o = p;

            Console.WriteLine("{0}, {1}", p.ToString(), o);
        }

        public void Test3()
        {
            Point p = new Point();

            object o = p;

            Console.WriteLine("{0}, {1}", p.ToString(), o);

            p = (Point)o;

            p.x = 2;

            Console.WriteLine("{0}, {1}", p.ToString(), o);

            o = p;

            Console.WriteLine("{0}, {1}", p.ToString(), o);
        }

        public void Test4()
        {
            Point p = new Point(1, 1);

            Console.WriteLine(p.ToString());

            p.Change(2, 2);

            Console.WriteLine(p.ToString());

            object o = p;

            Console.WriteLine(o);

            ((Point)o).Change(3, 3);

            Console.WriteLine(o);

            ((IChange)o).Change(4, 4);

            Console.WriteLine(o);
        }

        public void Test5()
        {
            int? a = null;

            object o = a;

            a = 5;

            o = a;
        }
    }

    interface IChange
    {
        void Change(int x, int y);
    }

    struct Point : IChange
    {
        internal int x;
        internal int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Change(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"x: {x}; y: {y}";
        }
    }
}
