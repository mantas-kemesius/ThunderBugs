using System;
using System.Collections;
using System.Collections.Generic;

namespace Foosball
{
    class SidesCommentator  //BallTracker?
    {
        private int _cmp=-1;
        private bool _check=false;
        public BallLocationChanges Ball = new BallLocationChanges();
        public string WhichSide(int x)//geriau propertis?
        {
            return x>289? "Ball is in the blue team area" : "Ball is in the red team area";
        }

        public void SetCmp (int x)
        {
            _cmp = x;
        }
        public void commentArea(int x)
        {
            if (x < 50) Ball.LocationCommentator(0, _check);
            else if (x.Between(50, 102)) Ball.LocationCommentator(1, _check);
            else if (x.Between(102, 178)) Ball.LocationCommentator(2, _check);
            else if (x.Between(178, 249)) Ball.LocationCommentator(3, _check);
            else if (x.Between(249, 337)) Ball.LocationCommentator(4, _check);
            else if (x.Between(337, 368)) Ball.LocationCommentator(5, _check);
            else if (x.Between(368, 470)) Ball.LocationCommentator(6, _check);
            else if (x.Between(470, 499)) Ball.LocationCommentator(7, _check);
            else if (x > 499) Ball.LocationCommentator(8, _check);
            else Ball.LocationCommentator(-1, _check);

            if (_cmp != x) _check = true;
        }
    }

}