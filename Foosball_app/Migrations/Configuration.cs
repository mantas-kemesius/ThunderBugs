namespace Foosball_app.Migrations
{
    using Foosball_app.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Foosball_app.Data.GameResultsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Foosball_app.Data.GameResultsDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Players.AddOrUpdate(
                t => t.PlayerName, trydata.GetPlayers().ToArray());
            context.SaveChanges();

            context.ManRodComm.AddOrUpdate(
                m => new { m.DateTime, m.RodComments}, trydata.GetManRodComm().ToArray());
            context.SaveChanges();

            context.Goals.AddOrUpdate(
                g => new { g.RodNames, g.DateTime }, trydata.GetGoals(context).ToArray());
            context.SaveChanges();
        }
    }
}
