namespace Foosball
{
    class blueScoreCounter: IScore
    {

        public int Goal(int y, int x)
        {
            if (x <= 413 && x >= 420 && y <= 85 && y >= 135)
            {
                return 1;
            }

            return 0;
        }

    }
}
