using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AnimalsDbContext _dbContext;
        public CommentRepository(AnimalsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(string comment, int animalID)
        {
            _dbContext.Comments.Add(new Comment { CommentContent = comment, AnimalID = animalID });
            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var toRemove = Read(id);
            _dbContext.Comments.Remove(toRemove);
            _dbContext.SaveChanges();
        }
        public void Delete(Comment comment)
        {
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Comment> Read()
        {
            return _dbContext.Comments.ToArray();
        }
        public Comment Read(int id)
        {
            return _dbContext.Comments.FirstOrDefault(c => c.ID == id);
        }
        public void Update(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
        }
    }
}
