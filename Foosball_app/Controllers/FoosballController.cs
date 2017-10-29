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
        // GET: Foosball
        public ActionResult Index()
        {
            return View();
        }
    }

}