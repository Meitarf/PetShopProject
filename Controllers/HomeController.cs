using Microsoft.AspNetCore.Mvc;
using PetShopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        public HomeController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        //show most popular animals
        public IActionResult Index()
        {
            return View(_animalRepository.TopAnimals());
        }
    }
}
