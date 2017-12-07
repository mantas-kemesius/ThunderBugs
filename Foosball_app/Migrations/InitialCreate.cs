using System;
using System.Data.Entity.Migrations;

namespace Foosball_app.Migrations
	{		
		public partial class InitialCreate : DbMigration
		{
			public override void Up()
			{

				CreateTable("dbo.Goals",
						c => new
						{
							GoalsId = c.Int(nullable: false, identity: true),
							RodNames = c.String(),
							DateTime = c.String(),
							RodComments = c.String(),
							PlayerId = c.Int(),
						})
					.PrimaryKey(t => t.GoalsId)
					.ForeignKey("dbo.Player", t => t.PlayerId)
					.Index(t => t.PlayerId);

				CreateTable("dbo.Player",
							c => new
							{
								PlayerId = c.Int(nullable: false, identity: true),
								PlayerName = c.String(),
							})
						.PrimaryKey(t => t.PlayerId);
							
				CreateTable("dbo.ManRodComm",
							c => new
							{
								ManRodCommId = c.Int(nullable: false, identity: true),
								DateTime = c.String(),
								RodComments = c.String(),
							})
						.PrimaryKey(t => t.ManRodCommId);

		}
			
			public override void Down()
			{
				DropForeignKey("dbo.Goals", "PlayerId", "dbo.Player");
				DropIndex("dbo.Goals", new string[] { "PlayerId" });
				DropTable("dbo.Player");
				DropTable("dbo.Goals");
				DropTable("dbo.ManRodComm");
			}
		}
	}
