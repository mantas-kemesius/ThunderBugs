namespace Foosball
{
    class Score
    {
        private int _goalCount = 0;

        public void redGoal (int x, int y)
        {
            if (x>=413 && x<=420 && y>=85 && y<=135)
                this._goalCount++;
        }

        public void blueGoal(int x, int y)
        {
            if (x <= 413 && x >= 420 && y <= 85 && y>= 135)
                this._goalCount++;
        }

        public int getGoalCount()
        {
            return this._goalCount;
        }
    }
}
