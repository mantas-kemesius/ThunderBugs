using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Foosball
{
    public class DBgoals
    {
        public int GoalsId { get; set; }
        public string RodNames { get; set; }
        public string DateTime { get; set; }
        
        //public int PlayerId { get; set; }//?
        public virtual DBplayer dbplayer { get; set; }
      
    }
}