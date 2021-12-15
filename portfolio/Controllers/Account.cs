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
    public class Account : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        public Account(SignInManager<User> SIM, UserManager<User> UM)
        {
            signInManager = SIM;
            userManager = UM;
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
    }
}
