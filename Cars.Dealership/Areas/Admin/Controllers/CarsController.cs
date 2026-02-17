using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Core.DTO.Cars;
using Cars.Dealership.Core.Mappings;
using Cars.Dealership.Core.ServiceContracts;
using Cars.Dealership.Infrastructure.FileStorageServiceContracts;
using Cars.Dealership.Infrastructure.FileStorageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Dealership.UI.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICarAdderService _carAdderService;
        private readonly IImageStorageService _imageStorageService;

        public CarsController(IWebHostEnvironment webHostEnvironment, ICarAdderService carAdderService, IImageStorageService imageStorageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _carAdderService = carAdderService;
            _imageStorageService = imageStorageService; 
        }





        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarRequest dto, List<IFormFile> images)
        {

            

            var car = CarMapper.ToEntity(dto); 

            car.Images = await _imageStorageService.StoreImage(images, _webHostEnvironment.WebRootPath, Guid.NewGuid());

            await _carAdderService.AddCarAsync(car);

            return Ok();
        }
    }

}
