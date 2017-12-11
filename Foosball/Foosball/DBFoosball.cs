namespace Foosball
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBFoosball : DbContext
    {
        public DBFoosball()
            : base("name=DBFoosball")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<GameComm> GameComm { get; set; }
        public virtual DbSet<Goals> Goals { get; set; }
        public virtual DbSet<Player> Player { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
