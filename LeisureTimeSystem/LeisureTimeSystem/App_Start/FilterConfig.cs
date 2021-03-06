﻿using System;
using System.Web;
using System.Web.Mvc;
using LeisureTimeSystem.Exceptions;

namespace LeisureTimeSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(NotAuthorizedException),
                View = "Error"
            });

            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(ArgumentException),
                View = "Error"
            });

            filters.Add(new HandleErrorAttribute());

        }
    }
}
