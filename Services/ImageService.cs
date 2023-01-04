using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class ImageService : IImageService
    {
        public string NewImage(string imageName, IFormFile imageFile)
        {
            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                imageFile.OpenReadStream().CopyTo(ms);
                bytes = ms.ToArray();
            }
            File.WriteAllBytes($"wwwroot\\Images\\{imageName}.jpg", bytes);
            return $"{imageName}.jpg";
        }
    }
}
