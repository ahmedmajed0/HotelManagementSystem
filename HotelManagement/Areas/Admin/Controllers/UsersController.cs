using Bl;
using HotelManagement.Areas.Admin.VwModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        SignInManager<ApplicationUser> signInManager;

        public UsersController(UserManager<ApplicationUser> umanager, RoleManager<IdentityRole> rmanager, SignInManager<ApplicationUser> inManager)
        {
            userManager = umanager;
            roleManager = rmanager;
            signInManager = inManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllUsers()
        {
            var users = await userManager.Users
                .Select(user => new UserVwModel { UserId = user.Id, FirstName = user.FirstName,
                    LastName = user.LastName,/*UserName = user.UserName,*/ Email = user.Email, Roles = (List<string>)userManager.GetRolesAsync(user).Result })
                .ToListAsync();
            return View(users);
        }




        public async Task<IActionResult> Add()
        {
            var allRoles = await roleManager.Roles.Select(role => new CheckBoxVwModel()
            {
                Id = role.Id,
                Name = role.Name,
            }
            ).ToListAsync();

            var vwModel = new AddUserVwModel()
            {
                Roles = allRoles
            };
            return View(vwModel);
        }




        [HttpPost]
        public async Task<IActionResult> Add(AddUserVwModel vwModel)
        {
            if (!ModelState.IsValid)
                return View(vwModel);

            //check if id == null

            if(!vwModel.Roles.Any(r => r.IsSelected))
            {
                ModelState.AddModelError("Roles", "Please select at least one role");
                return View(vwModel);
            }

            if(await userManager.FindByEmailAsync(vwModel.Email) != null)
            {
                ModelState.AddModelError("Email", "This email is exists");
                return View(vwModel);
            }

            //if (await userManager.FindByNameAsync(vwModel.UserName) != null)
            //{
            //    ModelState.AddModelError("UserName", "This username is exists");
            //    return View(vwModel);
            //}

            var user = new ApplicationUser()
            {
                FirstName = vwModel.FirstName,
                LastName = vwModel.LastName,
                Email = vwModel.Email,
                EmailConfirmed = true,
                UserName = vwModel.Email
            };

            var result = await userManager.CreateAsync(user, vwModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Roles", error.Description);
                }
                return View(vwModel);
            }

            await userManager.AddToRolesAsync(user, vwModel.Roles.Where(r => r.IsSelected).Select(r => r.Name));


            return RedirectToAction("AllUsers");
        }



        public async Task<IActionResult> Edit(string userid)
        {
            var user = await userManager.FindByIdAsync(userid);

            var vwModel = new UserFormVwModel()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                //UserName = user.Email,
            };
            return View(vwModel);
        }




        [HttpPost]
        public async Task<IActionResult> Edit(UserFormVwModel vwModel)
        {
            var user = await userManager.FindByIdAsync(vwModel.UserId);

            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(vwModel);

            var userWithSameEmail = await userManager.FindByEmailAsync(vwModel.Email);

            if(userWithSameEmail != null && userWithSameEmail.Id != user.Id)
            {
                ModelState.AddModelError("Email", "This email is asigned to another user");
                return View(vwModel);
            }


            //var userWithSameUsername = await userManager.FindByNameAsync(vwModel.UserName);

            //if (userWithSameUsername != null && userWithSameUsername.Id != user.Id)
            //{
            //    ModelState.AddModelError("UserName", "This username is asigned to another user");
            //    return View(vwModel);
            //}


            user.FirstName = vwModel.FirstName;
            user.LastName = vwModel.LastName;
            user.Email = vwModel.Email;
            user.UserName = vwModel.Email;


            await userManager.UpdateAsync(user);

            return RedirectToAction("AllUsers");
        }




        public async Task<IActionResult> ManageUserRoles(string userid)
        {
            var user = await userManager.FindByIdAsync(userid);

            if (user == null)
                return NotFound();

            var allRoles = await roleManager.Roles.ToListAsync();

            var vwModel = new UserRolesVwModel()
            {
                UserId = user.Id,
                UserEmail = user.Email,
                Roles = allRoles.Select(role => new CheckBoxVwModel() 
                { 
                    Id = role.Id,
                    Name = role.Name,
                    IsSelected = userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()

            };

            return View(vwModel);
        }



        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(UserRolesVwModel vwModel)
        {
            var user = await userManager.FindByIdAsync(vwModel.UserId);

            if (user == null)
                return NotFound();

            var oldUserRoles = await userManager.GetRolesAsync(user);

            //await userManager.RemoveFromRolesAsync(user, oldUserRoles);


            foreach (var role in vwModel.Roles)
            {
                if (role.IsSelected && !await userManager.IsInRoleAsync(user, role.Name))
                    await userManager.AddToRoleAsync(user, role.Name);

                if (!role.IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                    await userManager.RemoveFromRoleAsync(user, role.Name);
            }

            return RedirectToAction("AllUsers");
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("/Users/Login");

        }
    }
}
