using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using portfolio.Models.Authentication;
using portfolio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portfolio.Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;

namespace portfolio.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IAuthorizationService authService;
        public AccountController(SignInManager<User> SIM, UserManager<User> UM,IAuthorizationService IAS)
        {
            signInManager = SIM;
            userManager = UM;
            authService = IAS;
        }
        public IActionResult Register(string returnUrl = "/")
        {
            RegisterViewModel register = new RegisterViewModel() { ReturnUrl = returnUrl };
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel u)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { UserName = u.UserName, Email = u.Email };
                user.Id = Guid.NewGuid().ToString();
                var result = await userManager.CreateAsync(user, u.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return LocalRedirect(u.ReturnUrl??Url.Content("/"));
                }
                else
                {
                    foreach(var e in result.Errors)
                    {
                        ModelState.AddModelError("", e.Description);
                    }
                }
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel u)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(u.Email);
                //var result = await signInManager.PasswordSignInAsync(u.Email, u.Password, false, true);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    await signInManager.SignInAsync(user, false);
                    return LocalRedirect(u.ReturnUrl ?? "/");
                }
                else
                {
                    ModelState.AddModelError("", "ایمیل یا پسورد اشتباه است");
                }
            }
            return View();
        }
        public async Task<LocalRedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return LocalRedirect(returnUrl);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> Profile()
        {

            var isAdmin = await authService.AuthorizeAsync(User, "Admin");
            if (isAdmin.Succeeded)
            {
                return LocalRedirect("/Admin/Profile");
            }
            return View();
        }
    }
}
