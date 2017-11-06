using System;
using System.Collections;
using System.Collections.Generic;

namespace Foosball
{
    class SidesCommentator
    {   
        

        public string WhichSide(int x)//geriau propertis?
        {
            return x>289? "Ball is in the blue team area" : "Ball is in the red team area";
        }
        public string commentArea(int x)
        {

            //pasikeist, extention methodas pvz:isBetween, padavinet plikus skaicius, delegatu zodynas (func, grazinantis stringa)
            /* if (x < 50) return "Ball is near the red team gates";
             else if (x.Between(50, 102)) return "Ball is between red three and two man rods";
             else if (x.Between(102, 178)) return "Ball is between red two man and blue three man rods";
             else if (x.Between(178, 249)) return "Ball is between blue three man and red five man rods";
             else if (x.Between(249, 337)) return "Ball is between red five man and blue five man rods";
             else if (x.Between(337, 368)) return "Ball is between blue five man and red three man rods";
             else if (x.Between(368, 470)) return "Ball is between red three man and blue two man rods";
             else if (x.Between(470, 499)) return "Ball is between blue two and three man rods";
             else if (x > 499) return "Ball is near the blue team gates";
             else return "Ball is not detected";*/

            Dictionary<bool, Func<int, string>> LocationDictionary = new Dictionary<bool, Func<int, string>>
            {
            };

            LocationDictionary[x.Between(0, 50)] = new Func<int, string>
                (
                    (i) => { return BallLocation(i);}
                );

            return LocationDictionary[x.Between(0, 50)](1);
                /*{ x.Between(0, 50), BallLocation},
                { x.Between(50, 102), BallLocation},
                { x.Between(102, 178), BallLocation},
                { x.Between(178, 249), BallLocation},
                { x.Between(249, 337), BallLocation},
                { x.Between(337, 368), BallLocation},
                { x.Between(368, 470), BallLocation},
                { x.Between(470, 499), BallLocation},
                { x.Between(499, 520), BallLocation},*/
            //}

        }

        private static string BallLocation (int nr)
        {
            if (nr == 0) return "Ball is near the red team gates";
            else if (nr == 1) return "Ball is between red three and two man rods";
            else if (nr == 2) return "Ball is between red two man and blue three man rods";
            else if (nr == 3) return "Ball is between blue three man and red five man rods";
            else if (nr == 4) return "Ball is between red five man and blue five man rods";
            else if (nr == 5) return "Ball is between blue five man and red three man rods";
            else if (nr == 6) return "Ball is between red three man and blue two man rods";
            else if (nr == 7) return "Ball is between blue two and three man rods";
            else if (nr == 8) return "Ball is near the blue team gates";
            else return "Ball is not detected";
        }
    }

}