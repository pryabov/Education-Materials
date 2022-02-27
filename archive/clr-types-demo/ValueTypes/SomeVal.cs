namespace ValueTypes
{
    internal struct SomeVal
    {
        public SomeVal(int x)
        {
            this.x = x;
        }

        public static implicit operator SomeVal(int x)
        {
            return new SomeVal(x);
        }

        public static implicit operator int(SomeVal integer)
        {
            return integer.x;
        }

        public int x;
    }

}
