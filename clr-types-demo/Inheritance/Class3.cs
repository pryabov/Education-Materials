namespace Inheritance
{
    class Class3 : Interface1, Interface2
    {
        public int SomeMethod(int value)
        {
            return (value + 1) * 30;
        }

        int Interface1.SomeMethod(int value)
        {
            return (value + 1) * 40;
        }

        int Interface2.SomeMethod(int value)
        {
            return (value + 1) * 50;
        }
    }
}
