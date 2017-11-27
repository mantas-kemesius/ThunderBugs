namespace Foosball
{
    // TODO kimutis : file name does not match class name
    public static class IsBetween
    {
        public static bool Between(this int x, int value1, int value2)
        {
                return (x > value1 && x < value2) ? true : false;
        }
    }
}
