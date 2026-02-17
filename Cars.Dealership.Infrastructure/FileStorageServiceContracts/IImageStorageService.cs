using Cars.Dealership.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Dealership.Infrastructure.FileStorageServiceContracts
{
    public interface IImageStorageService
    {
        public Task<List<Image>> StoreImage(List<IFormFile> images, string webRootPath, Guid carId);

    }
}
