using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    class Commentator
    {
        private string firstPlayer;
        private string secondPlayer;
        private string comment;


        //Let commentator to know who playing
        public Commentator(string firstPlayer, string secondPlayer)
        {
            firstPlayer = "Blue team";
            secondPlayer = "Red team";
            setFirstPlayer(firstPlayer);
            setSecondPlayer(secondPlayer);
        }

        public string introduction()
        {
            comment = $"Welcome {getFirstPlayer()} and {getSecondPlayer()}!";

            return comment;
        }

        public string commentsAccordingCoordinates(int X, int Y)
        {
            comment = $"Kamuolys kordinatese: x =  {X} ir y = {Y}!!";
            return comment;
        }
        
        private void setFirstPlayer(string name)
        {
            firstPlayer = name;
        }

        private string getFirstPlayer()
        {
            return firstPlayer;
        }

        private void setSecondPlayer(string name)
        {
            secondPlayer = name;
        }

        private string getSecondPlayer()
        {
            return secondPlayer;
        }
    }
}
