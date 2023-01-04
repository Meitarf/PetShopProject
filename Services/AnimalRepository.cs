using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalsDbContext _dbContext;
        public AnimalRepository(AnimalsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Animal animal)
        {
             _dbContext.Animals.Add(animal);
             _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var toRemove = Read(id);
            _dbContext.Animals.Remove(toRemove);
            _dbContext.SaveChanges();
        }

        public void Delete(Animal animal)
        {
            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();
        }

        public Animal GetAnimalById(int id)
        {
            return _dbContext.Animals.Where(a => a.ID == id).FirstOrDefault();
        }

        public IEnumerable<Animal> Read()
        {
            return _dbContext.Animals.ToArray();
        }

        public Animal Read(int id)
        {
            return _dbContext.Animals.FirstOrDefault(a => a.ID == id);
        }

        public IEnumerable<Animal> TopAnimals()
        {
            return  _dbContext.Animals.OrderByDescending(a => a.Comments.Count()).Take(2).ToList();
        }

        public void Update(Animal animal)
        {
            _dbContext.Animals.Update(animal);
            _dbContext.SaveChanges();
        }
    }
}
