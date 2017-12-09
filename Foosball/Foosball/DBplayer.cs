using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Foosball
{
    public class DBplayer
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public virtual List<DBgoals> dbgoals { get; set; }

        public DBplayer ()
        {
            this.dbgoals = new List<DBgoals>();
        }

    }
}