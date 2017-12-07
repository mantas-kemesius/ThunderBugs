using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foosball_app.Models.GameResultsDB
{
    public class ManRodComm
    {
        public int ManRodCommId { get; set; }
        public string DateTime { get; set; }
        public string RodComments { get; set; }

        //List<ManRodComm> manRodComm = new List<ManRodComm>();    
    }
}