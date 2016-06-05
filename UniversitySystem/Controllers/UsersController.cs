using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Models;
using UniversitySystem.Repositories;
using UniversitySystem.Services;
using UniversitySystem.ViewModels.Account;
using UniversitySystem.ViewModels.User;

namespace UniversitySystem.Controllers
{
    public class UsersController : Controller
    {
        
        public ActionResult Register()
        {
            AccountRegisterVM model = new AccountRegisterVM();
            return View(model);
        }

        [HttpPost]       
        public ActionResult Register(AccountRegisterVM model)
        {

            User u = new User();
            UsersRepository usersRepo = new UsersRepository();

            u.Username = model.Username;
            u.Password = model.Password;
            u.FirstName = model.FirstName;
            u.LastName = model.LastName;


            usersRepo.Save(u);            
            return RedirectToAction("Login");
        }  


        public ActionResult Login(string RedirectUrl)
        {
            AccountLoginVM model = new AccountLoginVM();
            model.RedirectUrl = RedirectUrl;

            return View(model);
        }
        [HttpPost]
        public ActionResult Login()
        {
            AccountLoginVM model = new AccountLoginVM();
            TryUpdateModel(model);

            AuthenticationService.AuthenticateUser(model.Username, model.Password);
            if (AuthenticationService.LoggedUser != null)
            {
                if (!String.IsNullOrEmpty(model.RedirectUrl))
                    return Redirect(model.RedirectUrl);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationService.Logout();

            return RedirectToAction("Login");
        }        

        public ActionResult Edit(int? id)
        {
            User user = new User();
            UsersRepository usersRepo = new UsersRepository();
            UsersEditVM model = new UsersEditVM();

            if (id.HasValue)
            {
                user = usersRepo.GetById(id.Value);
                if (user == null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                user = new User();
            }

            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Username = user.Username;
            model.Password = user.Password;            

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            UsersEditVM model = new UsersEditVM();
            UsersRepository usersRepo = new UsersRepository();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user;
            if (model.ID == 0)
            {
                user = new User();
            }
            else
            {
                user = usersRepo.GetById(model.ID);
                if (user == null)
                {
                    return RedirectToAction("List");
                }
            }

            user.ID = model.ID;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Password = model.Password;
            user.Username = model.Username;

            usersRepo.Save(user);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            UsersRepository usersRepo = new UsersRepository();

            if (id.HasValue)
            {
                usersRepo.Delete(id.Value);
            }
            return RedirectToAction("List");
        }
    }
}
