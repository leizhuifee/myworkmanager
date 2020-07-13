using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWorkManager.Models;

namespace MyWorkManager.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

       
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult UpDataUser(string id)
        {
            var user = _userManager.FindByIdAsync(id);
            if (user!=null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpDataUser(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser  user=new IdentityUser()
                {
                    UserName = loginModel.UserName,
                    
                };
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return View();
                }
            }
            ModelState.AddModelError("","修改用户失败");
            return View();
        }

        public async Task<IActionResult> DeleteUser(string  id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user!=null)
            {
                var reslut = await _userManager.DeleteAsync(user);
                if (reslut.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","删除失败");
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("","没有找到要删除的用户");
            return RedirectToAction("Index");

        }
    }
}
