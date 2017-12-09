using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Foosball
{
    public class DBGameContext: DbContext
    {
        public DbSet<DBplayer> DBplayers { get; set; }
        public DbSet<DBmanRodComm> DBmanRodComm { get; set; }
        public DbSet<DBgoals> DBgoals { get; set; }
    }
}