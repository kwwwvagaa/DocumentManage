using DM.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DM.Web.Areas.Base.Controllers
{
    public class IndexPageController : BaseController
    {
        // GET: Base/IndexPage
        public ActionResult Index()
        {
            return View();
        }
    }
}