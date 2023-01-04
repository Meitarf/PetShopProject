using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Models
{
    public class Comment
    {
        [Key][Required]
        public int ID { get; set; }
        [Required]
        public int AnimalID { get; set; }
        [Required]
        public string CommentContent { get; set; }
    }
}
