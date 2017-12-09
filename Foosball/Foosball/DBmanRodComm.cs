using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Foosball
{
    public class DBmanRodComm
    {
        public int ManRodCommId { get; set; }
        public string DateTime { get; set; }
        public string RodComments { get; set; }

        //List<ManRodComm> manRodComm = new List<ManRodComm>();    
    }
}