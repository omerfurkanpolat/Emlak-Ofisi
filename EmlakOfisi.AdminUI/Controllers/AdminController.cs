using EmlakOfisi.AdminUI.Models;
using EmlakOfisi.Core.Constant;
using EmlakOfisi.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfisi.AdminUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public AdminController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        
        public ActionResult Index()
        {

            List<User> users = _userManager.Users.ToList();
            if (users.Count>0)
            {
                ListOfAgetViewModel agents = new ListOfAgetViewModel()
                {
                    ListOfAgent = users
                };
                return View(agents);
            }

            return View();
        }
         
        [HttpGet]
        public IActionResult CreateAgent()
        {
            return View(new AgentSignupViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgent(AgentSignupViewModel model)
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
                AgentCompanyName=model.AgentCompanyName

            };

            var result = await _userManager.CreateAsync(user, "123456");
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


            return RedirectToAction("Index", "Admin");
        }

    }
}
