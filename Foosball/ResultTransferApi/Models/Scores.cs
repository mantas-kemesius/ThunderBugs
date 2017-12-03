using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultTransferApi.Models
{
    public class Scores
    {
        public long Id { get; set; }
        public int RedTeamScore { get; set; }
        public int BlueTeamScore { get; set; }
        public string BlueTeam { get; set; }
        public string RedTeam { get; set; }
    }
}
