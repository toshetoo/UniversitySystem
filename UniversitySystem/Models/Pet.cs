using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class Pet : BaseModel
    {
        public string Breed { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }

        public int UserID { get; set; }

        public virtual User Owner { get; set; }
    }
}