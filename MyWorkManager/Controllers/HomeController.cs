using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWorkManager.Models;

namespace MyWorkManager.Controllers
{
    public class HomeController : Controller
    {
        public Servers.IHomeimg _homeimg;
        public HomeController(Servers.IHomeimg homeimg)
        {
            _homeimg = homeimg;
        }

        public IActionResult Index()
        {

            var homeimgs = _homeimg.GetHomeimgs();

            return View(homeimgs);
        }

      
    }
}
