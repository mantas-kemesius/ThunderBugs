namespace Foosball
{
    // TODO kimutis : class name should be starting with capital
    public class scoreSaver
    {
        private int _goalCount = 0;
        private IScore _score;

        public scoreSaver(IScore score)
        {
            this._score = score;
        }

        public void count(int x, int y)
        {
            this._goalCount += this._score.Goal(x, y);
        }

        // TODO kimutis : looks like from class score?
        public int getGoalCount()
        {
            return this._goalCount;

        }
    }
}