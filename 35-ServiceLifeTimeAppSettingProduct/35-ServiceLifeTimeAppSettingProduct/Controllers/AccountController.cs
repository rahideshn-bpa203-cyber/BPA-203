using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.ViewModels;
using _35_ServiceLifeTimeAppSettingProduct.ViewModels.Account;
using _35_ServiceLifeTimeAppSettingProductn.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace _35_ServiceLifeTimeAppSettingProduct.Controllers
{

    public class AccountController :Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager=signInManager;
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
                  ModelState.AddModelError(string.Empty,error.Description);

                
                }
                return View();
            
            }
            return RedirectToAction(nameof(HomeController.Index),"Home");

        //    return Json(registerVm);
        }

        public async Task<IActionResult> Login(LoginVM loginVM,string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginVM.UsernameOrEmail || u.Email == loginVM.UsernameOrEmail);
            if(user is null)
            {
                ModelState.AddModelError(string.Empty, "Username, Email or Password is  incorrect");
                return View();
            }
             var result=await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsPersistent, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username, Email or Password is  incorrect");
                return View();
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
