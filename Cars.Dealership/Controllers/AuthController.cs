using Microsoft.AspNetCore.Mvc;
using Cars.Dealership.Core.DTO.Auth;
using Microsoft.AspNetCore.Identity;
using Cars.Dealership.Core.Domain.IdentityEntities;
using Cars.Dealership.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Cars.Dealership.Core.Enums;


namespace Cars.Dealership.UI.Controllers
{
    [AllowAnonymous]
    [Route("")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager; 
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto dto)
        {
            // show errors (WIP)
            if (!ModelState.IsValid)
                return Content("Implement me later");


            var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, isPersistent: false, lockoutOnFailure: false);

            // show errors (WIP)
            if (!result.Succeeded)
                return Content("Implement me later");



            return RedirectToAction(nameof(HomeController.Index), "Home");


        }



        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto dto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = dto.Email,
                UserName = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };


            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var role = dto.IsAdmin ? UserTypeOptions.Admin.ToString() : UserTypeOptions.User.ToString();
            
            IdentityResult roleResult = await _userManager.AddToRoleAsync(user, role);
                
            if(!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);
            
            await _signInManager.SignInAsync(user, isPersistent: false);
            
            
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
           
                
            

        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
