using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.BusinessLayer.Services;
using DIMS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIMS_Core.Controllers
{
    [Route("users")]
    public class UserProfileController : BaseController
    {
        private readonly IUserProfileService _userProfileService;
        private readonly VUserProfileService _vUserProfileService;

        public UserProfileController(IMapper mapper, IUserProfileService userProfileService, VUserProfileService vUserProfileService) : base(mapper)
        {
            _userProfileService = userProfileService;
            _vUserProfileService = vUserProfileService;
        }

        public ActionResult Index()
        {
            var readOnlyModels = _vUserProfileService.GetAll();
            var viewModels = _mapper.Map<IEnumerable<VUserProfileViewModel>>(readOnlyModels);

            return View(viewModels);
        }

        [HttpGet("details/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            var userProfile = await _userProfileService.GetById(id);

            var userProfileViewModel = _mapper.Map<UserProfileViewModel>(userProfile);

            return View(userProfileViewModel);
        }

        [HttpGet("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserProfileViewModel userProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userProfileViewModel);
            }

            var userProfileEntity = _mapper.Map<UserProfileModel>(userProfileViewModel);

            var userProfile = await _userProfileService.Create(userProfileEntity);

            if (userProfile != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(userProfileViewModel);
        }

        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var userProfile = await _userProfileService.GetById(id);

            var userProfileViewModel = _mapper.Map<UserProfileViewModel>(userProfile);

            return View(userProfileViewModel);
        }

        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserProfileViewModel userProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userProfileViewModel);
            }

            var userProfileEntity = _mapper.Map<UserProfileModel>(userProfileViewModel);

            var userProfile = await _userProfileService.Update(userProfileEntity);

            if (userProfile != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(userProfileViewModel);
        }

        [HttpGet("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userProfileService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
