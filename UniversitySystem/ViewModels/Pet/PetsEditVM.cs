using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversitySystem.ViewModels.Pet
{
    public class PetsEditVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a breed!")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Breed is not valid!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Breed shoudl contain between 3 and 50 characters")]
        public string Breed { get; set; }

        [Required(ErrorMessage = "Please enter a name!")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Name is not valid!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name shoudl contain between 3 and 50 characters")]
        public string Name { get; set; }

        public string PicUrl { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}