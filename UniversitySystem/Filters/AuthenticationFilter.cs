﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Services;

namespace UniversitySystem.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationService.LoggedUser == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Users/Login?redirectUrl=" + filterContext.HttpContext.Request.Url);
                filterContext.Result = new EmptyResult();
            }

        }
    }
}