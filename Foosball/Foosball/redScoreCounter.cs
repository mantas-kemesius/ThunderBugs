namespace Foosball
{
    class redScoreCounter:IScore
    {
        public int Goal(int x, int y)
        {
            if (x >= 413 && x <= 420 && y >= 85 && y <= 135)
            {
                return 1;
            }

            return 0;
        }
    }
}
