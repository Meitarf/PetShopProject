using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Animal> GetAll();
        IEnumerable<Animal> GetAnimalByCategory(int id);
        Category GetCategoryById(int id);
        IEnumerable<Category> Read();

        Category Read(int id);

        void Create(Category category);

        void Update(Category category);

        void Delete(int id);

        void Delete(Category category);
    }
}
