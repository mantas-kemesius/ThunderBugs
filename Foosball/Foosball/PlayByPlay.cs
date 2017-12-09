using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    class PlayByPlay
    {
        BallFinder ballFinder = new BallFinder();
        private Dictionary<int, string> RodNames = new Dictionary<int, string>()
        {
            {1, "Dean"},
            {2, "Charles"},
            {3, "John Snow"},
            {4, "Sam"},
            {5, "Homer"},
            {6, "Bart"},
            {7, "Abraham"},
            {8, "Dylan"},
            {-1, "Man rod was not detected"}
        };
        public string WhichRod (int x, string team1, string team2)
        {
            if (ballFinder.commentArea(x) == 1 || ballFinder.commentArea(x) == 2 || ballFinder.commentArea(x) == 4 || ballFinder.commentArea(x) == 6)
            {
                return RodNames[ballFinder.commentArea(x)] + " at " + DateTime.Now.ToString()+ " ("+team1 + "team rod";
            }
            else
            {
                return RodNames[ballFinder.commentArea(x)] + " at " + DateTime.Now.ToString() + " ("+team2 + "team rod)";
            }
        }
    }
}
