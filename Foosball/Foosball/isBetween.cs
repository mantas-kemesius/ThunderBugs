namespace Foosball
{
    public static class IsBetween
    {
        public static bool Between(this int x, int value1, int value2)
        {
                return (x > value1 && x < value2) ? true : false;
        }
    }
}
