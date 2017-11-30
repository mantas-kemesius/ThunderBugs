namespace Foosball
{
    class BlueScoreCounter : IScore
    {
        public int Goal(int y, int x)
        {
            if (x.Between(420, 413) && y.Between(135, 85))
            {
                return 1;
            }

            return 0;
        }

    }
}