﻿using System.Web;
using System.Web.Mvc;

namespace oncloud.Web.oddBase
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
