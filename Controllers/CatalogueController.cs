using Microsoft.AspNetCore.Mvc;
using PetShopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Controllers
{
    public class CatalogueController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly ICommentRepository _commentRepository;
        public CatalogueController(ICategoryRepository categoryRepository, IAnimalRepository animalRepository, ICommentRepository commentRepository)
        {
            _categoryRepository = categoryRepository;
            _animalRepository = animalRepository;
            _commentRepository = commentRepository;
        }
        //show all animals
        //if a certain category is chosen - show all animal in specific CategoryId
        public IActionResult Index(int? id)
        {
            var animals = _categoryRepository.GetAll();
            if (id != null) animals = _categoryRepository.GetAnimalByCategory(id.Value);
            return View(animals);
        }
        
        public IActionResult Animal(int? id, string comment)
        {
            //if comment has value, add comment to specific AnimalID
            if (comment != null) _commentRepository.Create(comment, id.Value);
            //show specific animal by id
            var animal = _animalRepository.GetAnimalById(id.Value);
            //save category name to viewbag using CayegoryID
            ViewBag.Category = _categoryRepository.GetCategoryById(animal.CategoryID);
            return View(animal);
        }
    }
}
