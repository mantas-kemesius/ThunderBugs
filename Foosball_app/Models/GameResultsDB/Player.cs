using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foosball_app.Models.GameResultsDB
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        List<Player> players = new List<Player>();
    }
}