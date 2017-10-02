using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    class Score
    {
        private int goalCount = 0;

        public void redGoal (int x, int y)
        {
            if (x >= 413)
                if (x <= 420)
                    if (y >= 85)
                        if (y <= 135)
                            this.goalCount++;
        }

        public void blueGoal(int x, int y)
        {
            if (x >= 413)
                if (x <= 420)
                    if (y >= 85)
                        if (y <= 135)
                            this.goalCount++;
        }

        public int getGoalCount()
        {
            return this.goalCount;
        }
    }
}
