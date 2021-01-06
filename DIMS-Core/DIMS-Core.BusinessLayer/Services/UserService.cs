using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models.Account;
using DIMS_Core.Identity.Entities;
using DIMS_Core.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.BusinessLayer.Services
{
    internal class UserService : IdentityService, IUserService
    {
        public UserService(IIdentityUnitOfWork identityUnitOfWork, IMapper mapper) : base(identityUnitOfWork, mapper)
        {
        }

        public async Task<SignInResult> SignInAsync(SignInModel model)
        {
            var result = await _unitOfWork.SignInManager.PasswordSignInAsync(model.Email,
                                                                             model.Password,
                                                                             model.RememberMe,
                                                                             false);

            return result;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var mappedEntity = _mapper.Map<User>(model);

            var result = await _unitOfWork.UserManager.CreateAsync(mappedEntity, model.Password);

            return result;
        }

        public Task SignOutAsync()
        {
            return _unitOfWork.SignInManager.SignOutAsync();
        }
    }
}