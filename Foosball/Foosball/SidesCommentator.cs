using System.Collections;
namespace Foosball
{
    class SidesCommentator
    {
        ArrayList manRodCoord = new ArrayList{50, 102, 178, 249, 337, 368, 470, 499};

        public string WhichSide(int x)//geriau propertis?
        {
            return x>289? "Ball is in the blue team area" : "Ball is in the red team area";
        }
        public string commentArea(int x)
        {
            //pasikeist, extention methodas pvz:isBetween, padavinet plikus skaicius, delegatu zodynas (func, grazinantis stringa)
            if (x < (int)manRodCoord[0]) return "Ball is near the red team gates";
            else if (x > (int)manRodCoord[0] && x < (int)manRodCoord[1]) return "Ball is between red three and two man rods";
            else if (x > (int)manRodCoord[1] && x < (int)manRodCoord[2]) return "Ball is between red two man and blue three man rods";
            else if (x > (int)manRodCoord[2] && x < (int)manRodCoord[3]) return "Ball is between blue three man and red five man rods";
            else if (x > (int)manRodCoord[3] && x < (int)manRodCoord[4]) return "Ball is between red five man and blue five man rods";
            else if (x > (int)manRodCoord[4] && x < (int)manRodCoord[5]) return "Ball is between blue five man and red three man rods";
            else if (x > (int)manRodCoord[5] && x < (int)manRodCoord[6]) return "Ball is between red three man and blue two man rods";
            else if (x > (int)manRodCoord[6] && x < (int)manRodCoord[7]) return "Ball is between blue two and three man rods";
            else if (x > (int)manRodCoord[7]) return "Ball is near the blue team gates";
            else return "Ball is not detected";
        }
    }
}