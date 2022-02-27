namespace Inheritance
{
    internal class Class1 : Interface1, Interface2
    {
        public int SomeMethod(int value)
        {
            return (value + 1) * 10;
        }
    }
}
