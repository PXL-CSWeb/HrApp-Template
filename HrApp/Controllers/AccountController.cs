using HrApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        #region Login Username

        [HttpGet]
        public IActionResult LoginUserName()
        {
            return View();
        }

        //TODO

        #endregion

        #region Login Email

        [HttpGet]
        public IActionResult LoginEmail()
        {
            return View();
        }

        //TODO

        #endregion

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser
                {
                    Email = registerModel.Email,
                    UserName = registerModel.UserName
                };
                var result = await _userManager.CreateAsync(identityUser, registerModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            return View();
        }

        #endregion

        #region Logout

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #endregion
    }
}
