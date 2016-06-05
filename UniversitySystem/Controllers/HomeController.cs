using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Filters;
using UniversitySystem.Services;
using UniversitySystem.ViewModels.User;

namespace UniversitySystem.Controllers
{
    public class HomeController : Controller
    {
        [AuthenticationFilter]
        public ActionResult Index()
        {
            UsersEditVM model = new UsersEditVM();
            model.ID = AuthenticationService.LoggedUser.ID;
            model.FirstName = AuthenticationService.LoggedUser.FirstName;
            model.LastName = AuthenticationService.LoggedUser.LastName;
            model.Username = AuthenticationService.LoggedUser.Username;
            model.Password = AuthenticationService.LoggedUser.Password;
            model.PicUrl = AuthenticationService.LoggedUser.PicUrl;
            return View(model);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}