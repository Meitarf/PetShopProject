using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Models;
using PetShopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IImageService _imageService;
        public AdminController(ICategoryRepository categoryRepository, IAnimalRepository animalRepository, IImageService imageService)
        {
            _categoryRepository = categoryRepository;
            _animalRepository = animalRepository;
            _imageService = imageService;
        }
        //show all animals
        //if a certain category is chosen - show all animal in specific CategoryId
        public IActionResult Index(int? id)
        {
            var animals = _categoryRepository.GetAll();
            if (id != null) animals = _categoryRepository.GetAnimalByCategory(id.Value);
            return View(animals);
        }
        //edit specific animal
        public IActionResult Edit(int? id)
        {
            var animal = _animalRepository.GetAnimalById(id.Value);
            return View(animal);
        }
        public IActionResult EditPost(Animal animal, IFormFile imageFile)
        {
            //check if the animal edited in "edit" is valid
            //if not - return to "edit" with validation summary
            if (!ModelState.IsValid) return View("edit", animal);
            //if new image is added - save image in DB
            if (imageFile != null) animal.PictureName = _imageService.NewImage(animal.Name, imageFile);
            //if image didn't change - keep the same image
            if (imageFile == null) animal.PictureName = $"{animal.Name}.jpg";
            //if valid - update and return to index
            _animalRepository.Update(animal);
            return RedirectToAction("index");
        }
        public IActionResult New()
        {
            return View();
        }
        public IActionResult NewPost(Animal animal, IFormFile imageFile)
        {
            //check if the animal created in "new" is valid
            //if not - return to "new" with validation summary
            if (!ModelState.IsValid) return View("new", animal);
            //if new image is added - save image in DB
            if (imageFile != null) animal.PictureName = _imageService.NewImage(animal.Name, imageFile);
            //if valid - add and return to index
            _animalRepository.Create(animal);
            return RedirectToAction("index");
        }
        //delete by specific id
        //return to index (admin)
        public IActionResult Delete(int? id)
        {
            if (id != null) _animalRepository.Delete(id.Value);
            return RedirectToAction("index");
        }
    }
}
