using EmalkOfisi.AgentUI.Models;
using EmlakOfisi.Business.Abstract;
using EmlakOfisi.Core.Constant;
using EmlakOfisi.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmalkOfisi.AgentUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IStateAdService _stateAdService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IStateAdService stateAdService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _stateAdService = stateAdService;
        }
        public IActionResult Index()
        {
            List<StateAd> stateAds = _stateAdService.GetStateAdByUserId(int.Parse(User.Claims.First().Value));
            UserStateAdsListViewModel model = new UserStateAdsListViewModel()
            {
                StateAds = stateAds.OrderByDescending(x => x.StateId).ToList()
            };
            
            return View(model);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Account");

            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
;            return View(model);
        }

        [HttpGet]
        public ActionResult CreateSateAd()
        {
            return View(new CreateStateAdViewModel());
        }
        [HttpPost]
        public ActionResult CreateSateAd(CreateStateAdViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            StateAd stateAd = new StateAd()
            {
                AdName = model.AdName,
                SatateAge = model.SatateAge,
                StateArea = model.StateArea,
                RoomCount = model.RoomCount,
                Description = model.Description,
                UserId=int.Parse(User.Claims.First().Value)
            };

            _stateAdService.CreateStateAd(stateAd);
            return RedirectToAction("Index", "Account");
        }
        [HttpGet]
        public ActionResult UpdateSateAd(int id)
        {
            StateAd stateAd = _stateAdService.GetStateAdById(id);
            UpdateStateAdViewModel model = new UpdateStateAdViewModel() { 
                StateId=stateAd.StateId,
                AdName=stateAd.AdName,
                SatateAge=stateAd.SatateAge,
                StateArea=stateAd.StateArea,
                RoomCount=stateAd.RoomCount,
                Description=stateAd.Description

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateSateAd(UpdateStateAdViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            StateAd stateAd = _stateAdService.GetStateByUserIdAndStateAdId(int.Parse(User.Claims.First().Value), model.StateId);
            if (stateAd==null)
            {
                ModelState.AddModelError("", Messages.YourDontUptadeAnotherUserStateAd);
                return View(model);
            }
            stateAd.AdName = model.AdName;
            stateAd.SatateAge = model.SatateAge;
            stateAd.StateArea = model.StateArea;
            stateAd.RoomCount = model.RoomCount;
            stateAd.Description = model.Description;
            _stateAdService.Update(stateAd);

            return RedirectToAction("Index", "Account");
        }
        [HttpPost]
        public ActionResult DeleteSateAd(int id)
        {
            _stateAdService.Delete(id);
            return RedirectToAction("Index", "Account");
        }



    }
}
