namespace Foosball
{
    // TODO kimutis : class should start with capital letter
    class redScoreCounter : IScore
    {
        public int Goal(int x, int y)
        {
            // TODO kimutis : refactor with extension method
            if (x >= 413 && x <= 420 && y >= 85 && y <= 135)
            {
                return 1;
            }

            return 0;
        }
    }
}