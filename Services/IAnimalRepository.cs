using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> TopAnimals();
        IEnumerable<Animal> Read();
        Animal GetAnimalById(int id);

        Animal Read(int id);

        void Create(Animal animal);

        void Update(Animal animal);

        void Delete(int id);

        void Delete(Animal animal);
    }
}
