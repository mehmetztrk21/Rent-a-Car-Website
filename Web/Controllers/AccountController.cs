using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Identity;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            TempData["error"] = null;
            TempData["success"] = null;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.username);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı yok.");
                TempData["error"] = "Kullanıcı adı hatalı.";
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.password, false, false);
            if (result.Succeeded)
            {
                TempData["success"] = "Hoş geldiniz.";
                return RedirectToAction("Edit", "Generals");
            }
            TempData["error"] = "Şifre hatalı.";

            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}
