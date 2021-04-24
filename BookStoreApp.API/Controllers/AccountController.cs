using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Contracts.Interface;
using BookStoreApp.Contracts.Models;
using System.Threading.Tasks;

namespace BookStoreApp.BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountData _accountData;
        public AccountController(IAccountData accountData)
        {
            _accountData = accountData;
        }
        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignupUserModel signupUserModel)
        {
            if (ModelState.IsValid)
            {
                var res = await _accountData.CreateUserAsync(signupUserModel);
                if (!res.Succeeded)
                {
                    foreach(var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(signupUserModel);
                }
                ModelState.Clear();
                return RedirectToAction(nameof(Login));
            }
            return View(signupUserModel);
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel loginUserModel)
        {
            if (ModelState.IsValid)
            {
                var res = await _accountData.LoginUserAsync(loginUserModel);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View();
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountData.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
