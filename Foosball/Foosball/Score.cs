namespace Foosball
{
    class Score
    {
        private int _goalCount = 0;

        public void redGoal (int x, int y)
        {
            if (x >= 413)
                if (x <= 420)
                    if (y >= 85)
                        if (y <= 135)
                            this._goalCount++;
        }

        public void blueGoal(int x, int y)
        {
            if (x <= 413)
                if (x >= 420)
                    if (y <= 85)
                        if (y >= 135)
                            this._goalCount++;
        }

        public int getGoalCount()
        {
            return this._goalCount;
        }

        public long getLongGoalCount()
        {
            return (long)this._goalCount;
        }

        public int convertLongGoalCount()
        {
            return (int)this._goalCount;
        }

    }
}
