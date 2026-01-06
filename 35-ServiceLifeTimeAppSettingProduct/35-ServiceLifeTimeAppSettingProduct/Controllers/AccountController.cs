using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.ViewModels.Account;
using _35_ServiceLifeTimeAppSettingProductn.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _35_ServiceLifeTimeAppSettingProduct.Controllers
{

    public class AccountController :Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new()
            {
                Name = registerVm.Name,
                Surname = registerVm.Surname,
                UserName = registerVm.UserName,
                Email = registerVm.Email,

            };
            IdentityResult result=await _userManager.CreateAsync(appUser, registerVm.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors) 
                { 
                  ModelState.AddModelError("",error.Description);

                
                }
                return View();
            
            }
            return RedirectToAction(nameof(HomeController.Index),"Home");

        //    return Json(registerVm);
        }
    }
}
