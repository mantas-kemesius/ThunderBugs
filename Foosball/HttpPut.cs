using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Foosball
{
    class HttpPut
    {
        private class Output
        {
            public int RedTeamScore { get; set; }
            public int BlueTeamScore { get; set; }
            public string BlueTeam { get; set; }
            public string RedTeam { get; set; }

            public Output(string redTeam, int redTeamScore, string blueTeam, int blueTeamScore)
            {
                RedTeamScore = redTeamScore;
                BlueTeamScore = blueTeamScore;
                BlueTeam = blueTeam;
                RedTeam = redTeam;
            }
        }

        public void Put(string redTeam, int redTeamScore, string blueTeam, int blueTeamScore)
        {/*
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(frmMain.url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            Output output = new Output(redTeam, redTeamScore, blueTeam, blueTeamScore);
            string jsonOut = JsonConvert.SerializeObject(output);
            httpWebRequest.ContentLength = jsonOut.Length;
            using (var writer = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                writer.Write(jsonOut);
            }
            var response = httpWebRequest.GetResponse() as HttpWebResponse;
        */}
    }
}
