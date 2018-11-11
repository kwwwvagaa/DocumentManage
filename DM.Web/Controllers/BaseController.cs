using DM.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DM.Interface.IService;
using DM.Domain;

namespace DM.Web.Controllers
{
    public class BaseController : Controller
    {
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Index(string modelid = null)
        {
            if (!string.IsNullOrEmpty(modelid))
            {
                Sys_PageIndex items = AutofacContainer.Resolve<ISys_PageIndexService>().FindEntity(modelid);
                ViewBag.PageConfig = items;
            }
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Form()
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Details()
        {
            return View();
        }
        protected virtual ActionResult Success(string message)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message }.ToJson());
        }
        protected virtual ActionResult Success(string message, object data)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message, data = data }.ToJson());
        }
        protected virtual ActionResult Error(string message)
        {
            return Content(new AjaxResult { state = ResultType.error.ToString(), message = message }.ToJson());
        }
        [HttpGet]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        public virtual ActionResult GetTableList(Pagination pagination, Dictionary<string,string> searchdata)
        {
            try
            {
                if (searchdata.ContainsKey("__RequestVerificationToken"))
                    searchdata.Remove("__RequestVerificationToken");
                string str = AutofacContainer.Resolve<IServiceBase>().GetTableList(pagination, searchdata);
                return Content(str);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}