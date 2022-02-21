namespace PrimitiveTypes
{
    public class Checked_Unchecked
    {
        public void Checked()
        {
            byte b = 100;

            checked
            {
                b = (byte)(b + 200);
            }
            uint a = unchecked((uint)-1);
        }
    }
}
