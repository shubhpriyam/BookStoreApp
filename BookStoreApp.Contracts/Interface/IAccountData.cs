using Microsoft.AspNetCore.Identity;
using BookStoreApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Contracts.Interface
{
    public interface IAccountData
    {
        Task<IdentityResult> CreateUserAsync(SignupUserModel signupUserModel);
        Task<SignInResult> LoginUserAsync(LoginUserModel loginUserModel);
        Task SignOutAsync();
    }
}
