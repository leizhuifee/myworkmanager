using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyWorkManager.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityUser> _roleManager;

        public  RoleController(UserManager<IdentityUser> userManager ,RoleManager<IdentityUser> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles =await  _roleManager.Roles.ToListAsync();

            return View(roles);
        }
        [HttpGet]
        public IActionResult AddRole()
        {

            return View();
        }
    }
}
