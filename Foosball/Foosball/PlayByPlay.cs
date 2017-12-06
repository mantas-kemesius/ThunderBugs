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
            {1, "Pasaka"},
            {2, "Gyveno"},
            {3, "Karta"},
            {4, "Senele"},
            {5, "Ir"},
            {6, "Senelis"},
            {7, "Su"},
            {8, "Drakonu"},
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
