using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Services;

namespace Foosball_app.Controllers
{
    public class FoosballController : Controller
    {
        //[HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        //[HttpPost]
        //public ActionResult IndexPost(VideoRecord video)
        //{
          //  var v = new VideoCapture();
         //   return View();
        //}
    }

}