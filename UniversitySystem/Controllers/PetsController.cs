using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Models;
using UniversitySystem.Repositories;
using UniversitySystem.Services;
using UniversitySystem.ViewModels.Pet;

namespace UniversitySystem.Controllers
{
    public class PetsController : Controller
    {
        public ActionResult List()
        {
            PetsListVM model = new PetsListVM();
            TryUpdateModel(model);

            model.Pets = new PetsRepository().GetAll().Where(p=> p.UserID == AuthenticationService.LoggedUser.ID).ToList();
            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            Pet pet = new Pet();
            PetsRepository petsRepo = new PetsRepository();
            PetsEditVM model = new PetsEditVM();

            if (id.HasValue)
            {
                pet = petsRepo.GetById(id.Value);
                if (pet == null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                pet = new Pet();
            }

            model.ID = pet.ID;
            model.Name = pet.Name;
            model.Breed = pet.Breed;
            model.PicUrl = pet.PicUrl;
            

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            PetsRepository petsRepo = new PetsRepository();
            PetsEditVM model = new PetsEditVM();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Pet pet;
            if (model.ID == 0)
            {
                pet = new Pet();
            }
            else
            {
                pet = petsRepo.GetById(model.ID);
                if (pet == null)
                {
                    return RedirectToAction("List");
                }
            }

            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                var imageExtension = Path.GetExtension(model.ImageUpload.FileName);

                if (String.IsNullOrEmpty(imageExtension) || !imageExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError(string.Empty, "Wrong image format.");
                }
                else
                {
                    string filePath = Server.MapPath("~/Uploads/");
                    model.PicUrl = model.ImageUpload.FileName;
                    model.ImageUpload.SaveAs(filePath + model.PicUrl);
                }
            }
            else
            {
                model.PicUrl = "default.jpg";
            }

            pet.ID = model.ID;
            pet.Name = model.Name;
            pet.Breed = model.Breed;
            pet.PicUrl = model.PicUrl;            

            petsRepo.Save(pet);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            PetsRepository petsRepo = new PetsRepository();

            if (id.HasValue)
            {
                petsRepo.Delete(id.Value);
            }
            return RedirectToAction("List");
        }
    }
}