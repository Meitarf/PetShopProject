using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> Read();

        Comment Read(int id);

        void Create(string comment, int animalID);

        void Update(Comment comment);

        void Delete(int id);

        void Delete(Comment comment);
    }
}
