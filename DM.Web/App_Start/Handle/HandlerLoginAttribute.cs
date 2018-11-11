using DM.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DM.Web
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Login")
                return;           
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                WebHelper.WriteCookie("dm_login_error", "overdue");
                //filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
        }
    }
}
