using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.ViewModels.Pet
{
    public class PetsListVM
    {
        public List<Models.Pet> Pets { get; set; }
    }
}