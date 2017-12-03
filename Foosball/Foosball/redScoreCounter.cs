namespace Foosball
{
    class RedScoreCounter : IScore
    {
        public int Goal(int x, int y)
        {
            if (x.Between(413, 420) && y.Between(85, 135))
            {
                return 1;
            }

            return 0;
        }
    }
}