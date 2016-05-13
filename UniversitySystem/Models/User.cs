using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PicUrl { get; set; }

        public virtual List<Pet> Pets { get; set; }
    }
}