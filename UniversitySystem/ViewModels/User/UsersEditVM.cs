using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversitySystem.ViewModels.User
{
    public class UsersEditVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a username!")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Username is not valid!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username shoudl contain between 3 and 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password!")]
        public string Password { get; set; }        

        [Required(ErrorMessage = "Please enter your name!")]
        [RegularExpression(@"^([A-z]+)$", ErrorMessage = "Name should consist only letters!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Your name should contain between 3 and 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        [RegularExpression(@"^([A-z]+)$", ErrorMessage = "Name should consist only letters!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Your name should contain between 3 and 50 characters")]
        public string LastName { get; set; }

        public string PicUrl { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}