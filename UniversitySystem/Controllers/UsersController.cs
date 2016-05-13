using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.Controllers
{
    public class UsersController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }
    }
}