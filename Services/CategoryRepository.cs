using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AnimalsDbContext _dbContext;
        public CategoryRepository(AnimalsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var toRemove = Read(id);
            _dbContext.Categories.Remove(toRemove);
            _dbContext.SaveChanges();
        }

        public void Delete(Category category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Animal> GetAll()
        {
            return _dbContext.Animals.ToArray();
        }

        public IEnumerable<Animal> GetAnimalByCategory(int id)
        {
            return _dbContext.Animals.Where(c => c.CategoryID == id).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Categories.Where(c => c.ID == id).FirstOrDefault();
        }

        public IEnumerable<Category> Read()
        {
            return _dbContext.Categories.ToArray();
        }

        public Category Read(int id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.ID == id);
        }

        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }
    }
}
