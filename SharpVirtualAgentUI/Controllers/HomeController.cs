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
            //WeatherApp app = new WeatherApp();

            //var report = app.Query("weather in delhi");



            return View();
        }

        //public async Task<ActionResult> IndexAsync()
        //{
        //    WeatherApp app = new WeatherApp();
        //    var report = await app.Query("weather in delhi");
        //    return View();
        //}

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