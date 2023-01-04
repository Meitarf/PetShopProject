using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Models
{
    public class Animal
    {
        [Key][Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0,500)]
        public string Age { get; set; }
        public string PictureName { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
