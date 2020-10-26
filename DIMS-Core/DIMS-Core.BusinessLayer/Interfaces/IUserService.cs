using DIMS_Core.BusinessLayer.Models.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

/// <summary>
/// This interface we use for working with Identity provider
/// </summary>

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IUserService : IService
    {
        Task<SignInResult> SignInAsync(SignInModel model);
        Task SignOutAsync();
        Task<IdentityResult> SignUpAsync(SignUpModel model);
    }
}