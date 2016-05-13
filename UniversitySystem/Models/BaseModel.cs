using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public abstract class BaseModel
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        
    }
}