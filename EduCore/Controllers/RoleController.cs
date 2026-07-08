using EduCore.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleFromReq)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleFromReq.RoleName;

                IdentityResult result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return View("Create");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("Create", roleFromReq);
        }
    }
}
