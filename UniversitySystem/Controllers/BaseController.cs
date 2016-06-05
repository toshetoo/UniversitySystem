using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Filters;

namespace UniversitySystem.Controllers
{
    [AuthenticationFilter]
    public class BaseController : Controller
    {
        
    }
}