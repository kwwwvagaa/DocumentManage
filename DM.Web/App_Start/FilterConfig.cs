﻿using System.Web;
using System.Web.Mvc;

namespace DM.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandlerLoginAttribute());
        }
    }
}
