using System;
using System.Collections.Generic;

namespace Foosball
{
    class BallLocationChanges
    {
        private Dictionary<int, string> BallLocation = new Dictionary<int, string>()
        {
            {0,"Ball is near the red team gates" },
            {1, "Ball is between red three and two man rods"},
            {2, "Ball is between red two man and blue three man rods"},
            {3, "Ball is between blue three man and red five man rods"},
            {4, "Ball is between red five man and blue five man rods"},
            {5, "Ball is between blue five man and red three man rods"},
            {6, "Ball is between red three man and blue two man rods"},
            {7, "Ball is between blue two and three man rods"},
            {8, "Ball is near the blue team gates"},
            {-1, "Ball is not detected"}
        };
        public string LocationCommentator(int DictKey, bool changed)
        {

            if (changed) return BallLocation[DictKey];
            else return ""; //pabandyt returnint null?
        }

        public string TimeCommentator(bool changed)
        {
            if (changed) return "(" + DateTime.Now.ToString() + ")";
            else return "";
        }
        public string WhichSide(int x, bool diffside)
        {
            if (diffside) return x > 289 ? HardcodedConstants.blue : HardcodedConstants.red;
            else return "";
        }

    }
}
