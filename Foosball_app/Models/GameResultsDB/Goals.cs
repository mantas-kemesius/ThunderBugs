using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foosball_app.Models.GameResultsDB
{
    public class Goals
    {
        public int GoalsId { get; set; }
        public string RodNames { get; set; }
        public string DateTime { get; set; }
        
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}