using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWorkManager.Models;
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
        public async Task< IActionResult> Index()
        {
          var covers= await  _coverRepository.GetCoversAsync();
            var groupcovers = covers.GroupBy(c => new { c.Colour, c.Sleeve, c.Size, c.Type }).Select(g=>new { Colour= g.Key.Colour, Sleeve=g.Key.Sleeve, Size=g.Key.Size, Type=g.Key.Type, Number=g.Sum(testc=>testc.Number)});
            List<Cover> Coversgroup = new List<Cover>();
            foreach (var item in groupcovers)
            {
                if (item.Type == "入库")
                {
                    Cover cover = new Cover();
                    cover.Colour = item.Colour;
                    cover.Sleeve = item.Sleeve;
                    cover.Size = item.Size;
                    cover.Number = item.Number;
                    Coversgroup.Add(cover);
                }

            }
            foreach (var item in groupcovers)
            {
                foreach (var i in Coversgroup)
                {
                    if (item.Type == "出库" && i.Colour == item.Colour)
                    {
                        i.Number -= item.Number;
                       
                    }
                }

            }


            return View(Coversgroup);
        }
        public async Task<IActionResult> AddCover()
        {


            return View();
        }

    }
}