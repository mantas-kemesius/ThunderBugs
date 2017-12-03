namespace Foosball
{
    public class ScoreSaver
    {
        private int _goalCount = 0;
        private IScore _score;

        public ScoreSaver(IScore score)
        {
            this._score = score;
        }

        public void count(int x, int y)
        {
            this._goalCount += this._score.Goal(x, y);
        }

        public int getGoalCount()
        {
            return this._goalCount;

        }
    }
}