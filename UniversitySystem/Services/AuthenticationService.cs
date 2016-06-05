using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;
using UniversitySystem.Repositories;

namespace UniversitySystem.Services
{
    public class AuthenticationService
    {
        public static User LoggedUser { get; set; }

        public static void AuthenticateUser(string username, string password)
        {
            LoggedUser = new UsersRepository().GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public static void Logout()
        {
            LoggedUser = null;
        }
    }
}