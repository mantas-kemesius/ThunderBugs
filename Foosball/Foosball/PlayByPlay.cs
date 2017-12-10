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
        public string WhichRod (int x)
        {
            return RodNames[ballFinder.commentArea(x)];
        }

        public DateTime Time ()
        {
            return DateTime.Now;
        }
    }
}
