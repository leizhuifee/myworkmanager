using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWorkManager.Dto;
using MyWorkManager.Models;

namespace MyWorkManager.Controllers
{
  //  [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
       
        private readonly RoleManager<IdentityRole> _roleManager;

        public  RoleController(RoleManager<IdentityRole> roleManager)
        {
           
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles =await  _roleManager.Roles.ToListAsync();
          
           
            return View(roles);
        }
        [HttpGet]
        public IActionResult CreatRole()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatRole( RoleCreatDto roleCreatDto)
        {
            if (!ModelState.IsValid)
            {
                return View(roleCreatDto);
            }

            var role = await _roleManager.FindByNameAsync(roleCreatDto.name);
            if (role!=null)
            {
                return View(roleCreatDto);
            }
            var newrole = new IdentityRole()
            {

                Name = roleCreatDto.name
            };
            var result = await _roleManager.CreateAsync(newrole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(roleCreatDto);
        }
    }
}
