using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class AnimalsDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public AnimalsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("PetShopDb");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Mammal" },
                new Category { ID = 2, Name = "Bird" },
                new Category { ID = 3, Name = "Fish" }
                );
            modelBuilder.Entity<Animal>().HasData(
                new Animal { ID = 1, Name = "Cat", Age = "3", CategoryID = 1, PictureName = "/cat.jpg", Description = "The best animal in the world" },
                new Animal { ID = 2, Name = "Dog", Age = "4", CategoryID = 1, PictureName = "/dog.jpg", Description = "Very cute" },
                new Animal { ID = 3, Name = "Parrot", Age = "2", CategoryID = 2, PictureName = "/parrot.jpg", Description = "Will repeat whatever you say" },
                new Animal { ID = 4, Name = "Starfish", Age = "1", CategoryID = 3, PictureName = "/starfish.jpg", Description = "He's a real star" },
                new Animal { ID = 5, Name = "Jellyfish", Age = "2", CategoryID = 3, PictureName = "/jellyfish.jpg", Description = "Nobody likes them" },
                new Animal { ID = 6, Name = "Cheetah", Age = "4", CategoryID = 1, PictureName = "/cheetah.jpg", Description = "Cheetos symbol" },
                new Animal { ID = 7, Name = "Dove", Age = "3", CategoryID = 2, PictureName = "/dove.jpg", Description = "It brings peace" }
                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { ID = 1, AnimalID = 1, CommentContent = "Very good" },
                new Comment { ID = 2, AnimalID = 1, CommentContent = "A good cat" },
                new Comment { ID = 3, AnimalID = 2, CommentContent = "Doggo" },
                new Comment { ID = 4, AnimalID = 3, CommentContent = "Amazing" },
                new Comment { ID = 5, AnimalID = 4, CommentContent = "Is it Patrick?" },
                new Comment { ID = 6, AnimalID = 5, CommentContent = "Terrible" },
                new Comment { ID = 7, AnimalID = 6, CommentContent = "Very fast" },
                new Comment { ID = 8, AnimalID = 6, CommentContent = "Cheetos are the best" },
                new Comment { ID = 9, AnimalID = 7, CommentContent = "A very good soap" },
                new Comment { ID = 10, AnimalID = 2, CommentContent = "Very good, but cats are still better." },
                new Comment { ID = 11, AnimalID = 5, CommentContent = "Stings. Please leave the ocean" }
                );
        }
        
    }
}
