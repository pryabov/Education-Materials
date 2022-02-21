namespace ValueTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeVal v1 = new SomeVal();

            int a = v1.x;

            Boxed_Unboxed v = new Boxed_Unboxed();

            v.Test2();

            v.Test4();

            v.Test5();
        }
    }
}
