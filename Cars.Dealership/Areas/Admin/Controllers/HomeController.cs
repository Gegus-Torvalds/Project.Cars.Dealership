using Cars.Dealership.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cars.Dealership.UI.Areas.AdminArea.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICarGetterService _carGetterService; 

        public HomeController(ICarGetterService carGetterService)
        {
            _carGetterService = carGetterService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _carGetterService.GetAllCarsAsync());
        }

        
    }
}
