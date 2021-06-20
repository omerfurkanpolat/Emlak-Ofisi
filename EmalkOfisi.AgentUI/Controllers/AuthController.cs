using EmalkOfisi.AgentUI.Models;
using EmlakOfisi.Core.Constant;
using EmlakOfisi.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmalkOfisi.AgentUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new AgentSignUpViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(AgentSignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User userName = await _userManager.FindByNameAsync(model.UserName);
            if (userName != null)
            {

                ModelState.AddModelError("", Messages.UserNameAlreadyExist);
                return View(model);
            }
            User user = new User()
            {
                UserName = model.UserName,
                Email = model.EmailAdress,

            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                string roleName = "agent";
                if (!_roleManager.RoleExistsAsync(roleName).Result)
                {
                    Role role = new Role() { Name = roleName };
                    var roleTesult = await _roleManager.CreateAsync(role);
                    if (!roleTesult.Succeeded)
                    {

                        ModelState.AddModelError("", Messages.RoleNotCreated);
                        return View(model);
                    }
                }
                var addRole = await _userManager.AddToRoleAsync(user, roleName);
            }
            else
            {

                ModelState.AddModelError("", Messages.UserNotCreated);
                return View(model);
            }


            return RedirectToAction("Login", "Auth");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", Messages.EmailNotFound);
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Account");

            }

            ModelState.AddModelError("", Messages.EmailOrPasswordWrong);
            return View(model);

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
           
            return Redirect("~/");
        }
    }
}
