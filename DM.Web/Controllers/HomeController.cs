using DM.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DM.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var b = AutofacContainer.Resolve<DM.Service.BusinessService.Sys_UserService>();
            string str = b.Test();
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