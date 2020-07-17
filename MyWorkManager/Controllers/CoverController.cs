using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWorkManager.Servers;

namespace MyWorkManager.Controllers
{
    public class CoverController : Controller
    {
        private readonly ICoverRepository _coverRepository;

        public CoverController(ICoverRepository coverRepository)
        {
            _coverRepository = coverRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            


            return View();
        }


    }
}