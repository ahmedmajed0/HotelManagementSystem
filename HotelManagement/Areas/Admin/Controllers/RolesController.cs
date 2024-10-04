using HotelManagement.Areas.Admin.Constants;
using HotelManagement.Areas.Admin.VwModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> role)
        {
            roleManager = role;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllRoles()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> NewRole(RoleFormVwModel model)
        {
            if (!ModelState.IsValid)
               return View("AllRoles", await roleManager.Roles.ToListAsync());

            if (await roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("Name", "Role is exist!");
                return View("AllRoles", await roleManager.Roles.ToListAsync());
            }
                

            await roleManager.CreateAsync(new IdentityRole(model.Name));

            
            return View("AllRoles" , await roleManager.Roles.ToListAsync());
        }


        public async Task<IActionResult> ManageRoleClaims(string roleId)
        {

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
                return NotFound();

            var roleClaims =  roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allCalims = Permissions.GetAllPermissions();

            var AllPermissions = allCalims.Select(c => new CheckBoxVwModel { Name = c }).ToList();

            foreach(var permission in AllPermissions)
                if (roleClaims.Any(c => c == permission.Name))
                    permission.IsSelected = true;

            var vwModel = new RolePermissionsVwModel()
            { 
                RoleId = roleId,
                RoleName = role.Name,
                Permissions = AllPermissions
            };


            return View(vwModel);
        }

        [HttpPost]
        public async Task<IActionResult> PManageRoleClaims(RolePermissionsVwModel model)
        {

            var role = await roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
                return NotFound();

            var roleClaims = await roleManager.GetClaimsAsync(role);

            foreach (var claim in roleClaims)
                await roleManager.RemoveClaimAsync(role, claim);

            var SelectedClaims = model.Permissions.Where(c => c.IsSelected).ToList();

            foreach (var claim in SelectedClaims)
                await roleManager.AddClaimAsync(role, new Claim("Permission" , claim.Name));


            return RedirectToAction(nameof(AllRoles));
        }


    }
}
