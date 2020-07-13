using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWorkManager.Models;

namespace MyWorkManager.Controllers
{
    public class AccountController : Controller
    {


        public readonly SignInManager<IdentityUser> _signInManager;
        public readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = await _userManager.FindByNameAsync(loginModel.UserName);//根据输入的用户名查询数据库是否存在
            if (user!=null)//如果存在
            {
                var reslut = await _signInManager.PasswordSignInAsync(user, loginModel.PassWord, false, false);//验证密码
                if (reslut.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("","用户名或密码错误");
            return View(loginModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {

            if (ModelState.IsValid)
            {
                var user=new IdentityUser()
                {
                    UserName = registerModel.UserName
                };
                var reslut = await _userManager.CreateAsync(user, registerModel.PassWord);
                if (reslut.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            
            ModelState.AddModelError("","注册用户失败");
            return View(registerModel);
          
          
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
