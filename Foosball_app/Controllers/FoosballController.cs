using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace Foosball_app.Controllers
{
    public class FoosballController : Controller
    {
        //[HttpGet]
        public ActionResult Index()
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HH6M4CE;Initial Catalog=Thunderbugs;Integrated Security=True;Pooling=False");
            
            con.Open();

           SqlCommand com = new SqlCommand("Select * from Comments LEFT JOIN Scores ON Comments.game_nr = Scores.game_nr;");
           com.CommandType = CommandType.Text;
           com.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dt = new DataTable();
            da.Fill(dt);
            // On all tables' rows
            List<string> data = new List<string>();
            string empty = "                                                                                                                                                                                                        ";
            foreach (DataRow dtRow in dt.Rows)
            {
                if (dtRow["playbyplay"].ToString() != empty && dtRow["comment"].ToString() != empty)
                {
                    data.Add(dtRow["redteam_time"].ToString() + "% | " + dtRow["blueteam_time"].ToString() + "%   | " + dtRow["playbyplay"].ToString() + "    |   " + dtRow["comment"].ToString());
                }
                ViewData["red"] = dtRow["redteam_name"].ToString();
                ViewData["blue"] = dtRow["blueteam_name"].ToString();
            }

                return View(data);
        }

        //[HttpPost]
        //public ActionResult IndexPost(VideoRecord video)
        //{
          //  var v = new VideoCapture();
         //   return View();
        //}
    }

}