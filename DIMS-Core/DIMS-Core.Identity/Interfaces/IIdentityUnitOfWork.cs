using System;
using DIMS_Core.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.Identity.Interfaces
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        SignInManager<User> SignInManager { get; }
        UserManager<User> UserManager { get; }
    }
}