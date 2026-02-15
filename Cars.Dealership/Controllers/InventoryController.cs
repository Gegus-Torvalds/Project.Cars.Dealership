using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Cars.Dealership.UI.Controllers
{
    [AllowAnonymous]
    public class InventoryController : Controller
    {
        public IActionResult Cars()
        {
            return View();
        }
    }
}
