using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public interface IImageService
    {
        string NewImage(string imageName, IFormFile formFile);
    }
}
