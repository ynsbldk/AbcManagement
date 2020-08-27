using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbcManagement.DataAccess.Data;
using AbcManagement.Entities.Entities;
using AbcManagement.Website.Helpers;
using AbcManagement.Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AbcManagement.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly DbContextOptions<AbcDbContext> _contextOptions;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILoggerFactory loggerFactory, DbContextOptions<AbcDbContext> contextOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _contextOptions = contextOptions;

        }

        [Route("register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    if (_userManager.Users.Count() > 1)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }

                    _logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    _logger.LogError("Error!", result);
                    ViewBag.alReady = "User is already please try again.";
                    return View("register", ViewBag.alRedy);

                }

            }

            // If we got this far, something failed, redisplay form
            return View("register", model);
        }

        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    using (var db = new AbcDbContext(_contextOptions, null))
                    {
                        var applicationUser = _signInManager.UserManager.Users.FirstOrDefault(x => x.Email == model.Email);
                        applicationUser.LastLoginTime = DateTime.Now;
                        db.Entry(applicationUser).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

                else
                {

                    ViewBag.inValid = "Invalid login attempt.";
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        } 
     
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return RedirectToAction("login");
        }

    }
}
