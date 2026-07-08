using System.Security.Claims;
using EduCore.Models;
using EduCore.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> UserManager;
        SignInManager<ApplicationUser> SignInManager;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            UserManager = _userManager;
            SignInManager = _signInManager;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userFromRegister)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser UserModel = new ApplicationUser();
                UserModel.UserName = userFromRegister.UserName;
                UserModel.PasswordHash = userFromRegister.Password;
                UserModel.Address = userFromRegister.Address;

                //Save New user in database
                IdentityResult result = await UserManager.CreateAsync(UserModel, userFromRegister.Password);

                if (result.Succeeded)
                {
                    //Sign in the user after register successfully in the system And create cookie for him
                    await SignInManager.SignInAsync(UserModel, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("Register", userFromRegister);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(LoginViewModel userFromRequest)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userFromDB =
                     await UserManager.FindByNameAsync(userFromRequest.UserName);
                if (userFromDB != null)
                {
                    bool found = await UserManager.CheckPasswordAsync(userFromDB, userFromRequest.Password);
                    if (found)
                    {
                        List<Claim> addClaim = new List<Claim>();
                        addClaim.Add(new Claim("Address", userFromDB.Address));

                        await SignInManager.
                            SignInWithClaimsAsync(userFromDB, userFromRequest.RememberMe , addClaim);
                      
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Account");
                }
            }
            return View("Login", userFromRequest);
        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion
    }
}
