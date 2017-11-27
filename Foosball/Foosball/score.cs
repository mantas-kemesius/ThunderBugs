namespace Foosball
{
    class Score
    {
        private int _goalCount = 0;

        public void redGoal (int x, int y)
        {
            // TODO kimutis : refactor using extension method
            if (x >= 413 && x <= 420 && y >= 85 && y <= 135)
            {
                this._goalCount++;
            }
        }

        public void blueGoal(int x, int y)
        {
            // TODO kimutis : refactor using extension method
            if (x <= 413 && x >= 420 && y <= 85 && y >= 135)
            {
                this._goalCount++;
            }
        }

        public int getGoalCount()
        {
            // TODO kimutis : why goal count is same for red and blue?
            return this._goalCount;
        }
    }
}
