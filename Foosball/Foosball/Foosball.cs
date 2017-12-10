using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Foosball
{
    public class Foosball
    {
        public int RedTeamScore { get; set; }
        public int BlueTeamScore { get; set; }

        public Foosball(int first, int sec)
        {
            RedTeamScore = first;
            BlueTeamScore = sec;
        }
    }
}