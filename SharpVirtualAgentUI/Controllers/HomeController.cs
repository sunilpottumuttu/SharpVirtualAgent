using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBTApp.Weather;
using System.Threading.Tasks;

namespace SharpVirtualAgentUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
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

        [HttpGet()]
        public JsonResult GetWeather(string sentence)
        {
            var app = new WeatherApp();
            var report = app.Query(sentence);
            return Json(report,JsonRequestBehavior.AllowGet);
        }

    }
}