using Cars.Dealership.Core.Domain.Entities;
using Cars.Dealership.Core.DTO.Cars;
using Cars.Dealership.Core.Mappings;
using Cars.Dealership.Core.ServiceContracts;
using Cars.Dealership.Infrastructure.FileStorageServiceContracts;
using Cars.Dealership.Infrastructure.FileStorageServices;
using Cars.Dealership.UI.Areas.AdminArea.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cars.Dealership.UI.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICarAdderService _carAdderService;
        private readonly IImageStorageService _imageStorageService;
        private readonly ICarGetterService _carGetterService;
        private readonly ICarUpdaterService _carUpdaterService;
        private readonly ICarDeleterService _carDeleterService; 
        public CarsController(ICarDeleterService carDeleterService, ICarUpdaterService carUpdaterService, ICarGetterService carGetterService, IWebHostEnvironment webHostEnvironment, ICarAdderService carAdderService, IImageStorageService imageStorageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _carAdderService = carAdderService;
            _imageStorageService = imageStorageService;
            _carGetterService = carGetterService;
            _carUpdaterService = carUpdaterService;
            _carDeleterService = carDeleterService;
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

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute]Guid id)
        {

            var car  = await _carGetterService.GetCarAsync(id);

            return View(car);
        }

        [HttpPost] 
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromForm]UpdateCarRequest dto)
        {
            dto.Id = id;
            await _carUpdaterService.UpdateCarAsync(dto);
            return RedirectToAction(nameof(HomeController.Index), "Home", new {area="Admin"});
        }

        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {

            bool result = await _carDeleterService.DeleteCarAsync(id);

            if (!result) BadRequest("Something went wrong"); 

            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "Admin" });
        }

    }

}
