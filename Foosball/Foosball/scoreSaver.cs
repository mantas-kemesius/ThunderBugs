namespace Foosball
{
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
            _goalCount += _score.Goal(x, y);
        }

        public int getGoalCount()
        {
            return this._goalCount;
        }
    }
}
