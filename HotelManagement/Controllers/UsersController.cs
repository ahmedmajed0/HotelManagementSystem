using Bl;
using HotelManagement.Areas.Admin.Constants;
using HotelManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class UsersController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> SignInManager;
        public UsersController(UserManager<ApplicationUser> user, SignInManager<ApplicationUser> signin)
        {
            userManager = user;
            SignInManager = signin;
        }

        public IActionResult AccessDenied()
        {
            return View();

        }


        public IActionResult Login(string? ReturnUrl)
        {
            return View(new UserLoginModel()
            {
                ReturnUrl = ReturnUrl
            }) ;
        }



        
        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return Redirect("/Users/Login");

        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userModel)
        {
            if(!ModelState.IsValid)
                return View(userModel);

            if (userModel.ReturnUrl == "/")
                userModel.ReturnUrl = "~/";


            if (string.IsNullOrEmpty(userModel.ReturnUrl))
                userModel.ReturnUrl = "~/";


            var user = await userManager.FindByEmailAsync(userModel.Email);

            if(user == null)
            {
                ModelState.AddModelError("Email", "NO user with this email");
                return View(userModel);
            }
            var result = await SignInManager.PasswordSignInAsync(userModel.Email, userModel.Password,true,true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Password", "Please enter the right password");
                return View(userModel);
            }
            if (await userManager.IsInRoleAsync(user, Roles.Receptionist.ToString()))
            {
                return Redirect(userModel.ReturnUrl);
            }
            else
                return Redirect("/Admin/Home/Index");
        }
    }
}
