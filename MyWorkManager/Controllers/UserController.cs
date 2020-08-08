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
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager ,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            this._roleManager = roleManager;
        }

       
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async  Task<IActionResult> UpDataUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            LoginModel loginuser= new LoginModel()
            {
                Id = user.Id,
                UserName = user.UserName
                
                
              
            };
            if (user!=null)
            {
                return View(loginuser);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpDataUser(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "请输入密码验证");
                return View(loginModel);
            }
           
            var user = await _userManager.FindByIdAsync(loginModel.Id);
            user.UserName = loginModel.UserName;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "修改用户失败");
            return View(loginModel);
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
        [HttpGet]
        public async Task<IActionResult>EditRolesToUser( string id )
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var user = await _userManager.FindByIdAsync(id);
            List<IdentityRole> inRoles = new List<IdentityRole>();
            foreach (var role in roles)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    inRoles.Add(role);
                   
                }
            }
            foreach (var item in inRoles)
            {
                roles.Remove(item);
            }
            var editUserRoleDto = new EditUserRoleDto()
            {
                Id=user.Id,
                UserName = user.UserName,
                NotInRoles=roles,
                InRoles= inRoles

            };
            return View(editUserRoleDto);
        }
        [HttpGet]
        public async Task<IActionResult>  AddRoleToUser(string ids)
        {
            string[] idstrs = ids.Split(',');
            var user = await _userManager.FindByIdAsync(idstrs[0]);
            var role = await _roleManager.FindByIdAsync(idstrs[1]);
               await _userManager.AddToRoleAsync(user, role.Name);
            var roles = await _roleManager.Roles.ToListAsync();
            
            List<IdentityRole> inRoles = new List<IdentityRole>();
            foreach (var item in roles)
            {
                if (await _userManager.IsInRoleAsync(user, item.Name))
                {
                    inRoles.Add(item);
                  
                }
            }
            foreach (var item in inRoles)
            {
                roles.Remove(item);
            }
            var editUserRoleDto = new EditUserRoleDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                NotInRoles = roles,
                InRoles = inRoles

            };
            return RedirectToAction("EditRolesToUser", editUserRoleDto);

        }
        [HttpGet]
        public async Task<IActionResult> RemoveRoleToUser(string ids)
        {
            string[] idstrs = ids.Split(',');
            var user = await _userManager.FindByIdAsync(idstrs[0]);
            var role = await _roleManager.FindByIdAsync(idstrs[1]);
            await _userManager.RemoveFromRoleAsync(user, role.Name);
            var roles = await _roleManager.Roles.ToListAsync();

            List<IdentityRole> inRoles = new List<IdentityRole>();
            foreach (var item in roles)
            {
                if (await _userManager.IsInRoleAsync(user, item.Name))
                {
                    inRoles.Add(item);

                }
            }
            foreach (var item in inRoles)
            {
                roles.Remove(item);
            }
            var editUserRoleDto = new EditUserRoleDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                NotInRoles = roles,
                InRoles = inRoles

            };
            return RedirectToAction("EditRolesToUser", editUserRoleDto);

        }

    }
}
