using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("UniversitySystemDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
       

    }
}