using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Foosball_app.Controllers
{
    public class Item
    {
        public int RedTeamScore { get; set; }
        public int BlueTeamScore { get; set; }
        public string BlueTeam { get; set; }
        public string RedTeam { get; set; }

     
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost:5000/api/scores/"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString);
            for (int i = 0; i < items.Count; i++)
            {
                ViewData["1"] = items[i].RedTeam;
                ViewData["2"] = items[i].RedTeamScore;
                ViewData["3"] = items[i].BlueTeamScore;
                ViewData["4"] = items[i].BlueTeam;

            }
          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}