using Foosball_app.Models.GameResultsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Foosball_app.Data
{
	public class trydata
	{
		public static List<Player> GetPlayers()
		{
			List<Player> players = new List<Player>()
			{
				new Player() {PlayerName = "Jonas"},
				new Player() {PlayerName = "Jose"}
			};
            return players;
		}

		public static List<ManRodComm> GetManRodComm()
		{
			List<ManRodComm> manRodComm = new List<ManRodComm>()
			{
				new ManRodComm()
				{
					DateTime = "2017-12-06 18:41:46",
					RodComments = "Mamamia",
				},
				 new ManRodComm()
				{
					DateTime = "2017-12-06 18:46:46",
					RodComments = "Nemeluok",
				},
				  new ManRodComm()
				{
					DateTime = "2017-12-06 18:41:48",
					RodComments = "Ane",
				}
			};
            return manRodComm;
		}

		public static List<Goals> GetGoals(GameResultsDBContext context)
		{
            List<Goals> goals = new List<Goals>()
            {
                 new Goals()
                 {
                    RodNames = "Senelis",
                    DateTime = "2017-12-06 19:41:48",
                    PlayerId = context.Players.Find("Jose").PlayerId
                 },
                 new Goals()
                 {
                    RodNames = "Drakonas",
                    DateTime = "2017-12-06 20:41:48",
                    PlayerId = context.Players.Find("Jonas").PlayerId
                 }
            };
            return goals;
		}
	}
}


			   
        
    
