using Cars.Dealership.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using Cars.Dealership.Infrastructure.FileStorageServiceContracts;
namespace Cars.Dealership.Infrastructure.FileStorageServices
{
    public class ImageStorageService : IImageStorageService
    {
        
        public ImageStorageService()
        {

        }

        public async Task<List<Image>> StoreImage(List<IFormFile> images, string webRootPath, Guid carId)
        {
            //  check if images are loaded (if images is null or images cout is 0) 
            //  check if it contains more than 4 images 
            //  find / create the upload path (using IWebHostEnvironment)
            //  check each individual photo if its null 
            //  find image extension
            //  check if it is contained in allowed extensions
            //  create image name and create full path for that image
            //  open stream in create mode and with this FilePath
            //  copy images bytes to selected destination in the stream 
            //  create image object with car id and fill existing fields
            //  and add it to list which will be returned
            //  -----------------
            //  add individual photos from list to car entity object
            //  save changes asynchronously to db through _applicationDbContext

            //  throw exception in future
            if (images is null || images.Count == 0)
                return new List<Image>();
            
            //  throw exception in future
            if (images.Count > 4)
                return new List<Image>();

            string uploadPath = Path.Combine(webRootPath, "images", "cars");
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg" };
            Directory.CreateDirectory(uploadPath);
            List<Image> returnResult = new List<Image>();

            bool isCover = true;

            foreach(IFormFile image in images)
            {
                if (image.Length == 0) continue;

                string fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();

                //  throw exception in future
                if (!allowedExtensions.Contains(fileExtension))
                    continue;

                string fileName = Guid.NewGuid() + fileExtension;

                string fullPath = Path.Combine(uploadPath, fileName);


                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    await image.CopyToAsync(stream); 

                }

                var img = new Image()
                {
                    Id = Guid.NewGuid(),
                    ImageUrl = $"images/cars/{fileName}",
                    CarId = carId,
                    IsCover = isCover,

                }; 


                returnResult.Add(img);

                isCover = false;
            }


            return returnResult;
        }
    }
}
