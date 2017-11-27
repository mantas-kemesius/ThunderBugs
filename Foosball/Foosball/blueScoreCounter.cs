namespace Foosball
{
    // TODO kimutis : class name should be starting from capital
    class blueScoreCounter : IScore
    {
        // TODO kimutis : Goal name does not say what it does
        public int Goal(int y, int x)
        {
            // TODO kimutis : should be refactored with created extension method
            if (x <= 413 && x >= 420 && y <= 85 && y >= 135)
            {
                return 1;
            }

            return 0;
        }

    }
}