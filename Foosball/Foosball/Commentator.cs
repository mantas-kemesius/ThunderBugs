using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    class Commentator
    {
        private string _firstPlayer;
        private string _secondPlayer;
        private string _comment;


        //Let commentator to know who playing
        public Commentator(string _firstPlayer, string _secondPlayer)
        {
            _firstPlayer = "Blue team";
            _secondPlayer = "Red team";
        }

        public string introduction()
        {
            _comment = $"Welcome {FirstPlayer} and {SecondPlayer}!";

            return _comment;
        }

        public string commentsAccordingCoordinates(int X, int Y)
        {
            _comment = $"Kamuolys kordinatese: x =  {X} ir y = {Y}!!";
            return _comment;
        }
        
        private string FirstPlayer
        {
            get;
            set;
        }

        private string SecondPlayer
        {
            get;
            set;
        }

    }
}
