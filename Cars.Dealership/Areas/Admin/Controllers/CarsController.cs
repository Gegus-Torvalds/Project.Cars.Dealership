using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Dealership.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class CarsController : Controller
    {
        public IActionResult Create(Guid id)
        {
            return View();
        }
    }
}
