using Cars.Dealership.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Cars.Dealership.UI.Controllers
{
    [AllowAnonymous]
    public class InventoryController : Controller
    {
        private readonly ICarGetterService _carGetterService; 


        public InventoryController(ICarGetterService carGetterService)
        {
            _carGetterService = carGetterService;
        }

        public async Task<IActionResult> Cars()
        {
            var cars = await _carGetterService.GetAllCarsAsync(); 
            return View(cars);
        }


    }
}
