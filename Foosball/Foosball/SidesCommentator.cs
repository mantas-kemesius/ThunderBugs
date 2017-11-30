using System;
using System.Collections;
using System.Collections.Generic;

namespace Foosball
{
    class SidesCommentator  //BallTracker?
    {
        public string WhichSide(int x)//geriau propertis?
        {
            return x>289? "Ball is in the blue team area" : "Ball is in the red team area";
        }

        public int commentArea(int x)
        {
            if (x < 50) return 0;
            else if (x.Between(50, 102))  return 1;
            else if (x.Between(102, 178)) return 2;
            else if (x.Between(178, 249)) return 3;
            else if (x.Between(249, 337)) return 4;
            else if (x.Between(337, 368)) return 5;
            else if (x.Between(368, 470)) return 6;
            else if (x.Between(470, 499)) return 7;
            else if (x > 499) return 8;
            else return -1;
        }
    }

}
 