using Microsoft.AspNetCore.Identity;
using BookStoreApp.Contracts.Interface;
using BookStoreApp.Contracts.Models;
using System;
using System.Threading.Tasks;

namespace BookStoreApp.Domain
{
    public class AccountData : IAccountData
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountData(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignupUserModel signupUserModel)
        {
            var user = new ApplicationUser()
            {
                FirstName=signupUserModel.FirstName,
                LastName=signupUserModel.LastName,
                Email = signupUserModel.Email,
                UserName = signupUserModel.Email,
            };
            var result = await _userManager.CreateAsync(user, signupUserModel.Password);
            return result;
        }

        public async Task<SignInResult> LoginUserAsync(LoginUserModel loginUserModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserModel.Email, loginUserModel.Password, loginUserModel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
