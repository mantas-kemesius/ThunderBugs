using Foosball_app.Models.GameResultsDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Foosball_app.Data
{
    public class GameResultsDBContext: DbContext
    {
        public GameResultsDBContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<GameResultsDBContext>(new DropCreateDatabaseIfModelChanges<GameResultsDBContext>());
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<ManRodComm> ManRodComm { get; set; }
        public DbSet<Goals> Goals { get; set; }
    }
}