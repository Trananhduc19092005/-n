﻿using System.Web;
using System.Web.Mvc;

namespace Đồ_Án_Newspaper
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
