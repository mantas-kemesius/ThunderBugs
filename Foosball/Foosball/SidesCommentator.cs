using System.Collections;
namespace Foosball
{
    class SidesCommentator
    {
        private string _comment;
        ArrayList manRodCoord = new ArrayList();


        public SidesCommentator()
        {
            manRodCoord.Add(50);
            manRodCoord.Add(102);
            manRodCoord.Add(178);
            manRodCoord.Add(249);
            manRodCoord.Add(337);
            manRodCoord.Add(368);
            manRodCoord.Add(470);
            manRodCoord.Add(499);
        }

        public string commentsSide(int x)
        {

            if (x >= 289) return _comment = "Ball is in the blue team area";
            else return _comment = "Ball is in the red team area";
            
            
        }
        public string commentArea(int x)
        {
            if (x < (int)manRodCoord[0]) return _comment = "Ball is near the red team gates";
            else if (x > (int)manRodCoord[0] && x < (int)manRodCoord[1]) return _comment = "Ball is between red three and two man rods";
            else if (x > (int)manRodCoord[1] && x < (int)manRodCoord[2]) return _comment = "Ball is between red two man and blue three man rods";
            else if (x > (int)manRodCoord[2] && x < (int)manRodCoord[3]) return _comment = "Ball is between blue three man and red five man rods";
            else if (x > (int)manRodCoord[3] && x < (int)manRodCoord[4]) return _comment = "Ball is between red five man and blue five man rods";
            else if (x > (int)manRodCoord[4] && x < (int)manRodCoord[5]) return _comment = "Ball is between blue five man and red three man rods";
            else if (x > (int)manRodCoord[5] && x < (int)manRodCoord[6]) return _comment = "Ball is between red three man and blue two man rods";
            else if (x > (int)manRodCoord[6] && x < (int)manRodCoord[7]) return _comment = "Ball is between blue two and three man rods";
            else if (x > (int)manRodCoord[7]) return _comment = "Ball is near the blue team gates";
            else return _comment = "Ball is not detected";
        }

        public string Comment
        {
            get => _comment;
        }
    }
}