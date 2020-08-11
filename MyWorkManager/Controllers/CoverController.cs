using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWorkManager.Dto;
using MyWorkManager.Models;
using MyWorkManager.QueryParameters;
using MyWorkManager.Servers;
using MyWorkManager.viewModels;

namespace MyWorkManager.Controllers
{
    [Authorize]
    public class CoverController : Controller
    {
        private readonly ICoverRepository _coverRepository;
        private readonly IMapper _mapper;
        private List<Cover> stockcoversnumber = new List<Cover>();
        public CoverController(ICoverRepository coverRepository,IMapper mapper)
        {
            _coverRepository = coverRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
          var covers= await  _coverRepository.GetCoversAsync(null);
            var groupcovers = covers.GroupBy(c => new { c.Colour, c.Sleeve, c.Size, c.Type }).Select(g => new { Colour = g.Key.Colour, Sleeve = g.Key.Sleeve, Size = g.Key.Size, Type = g.Key.Type, Number = g.Sum(testc => testc.Number) });
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

            stockcoversnumber = Coversgroup;
            return View(Coversgroup);
        }
        [Authorize(Roles =("Admin"))]
        [HttpGet]
        public async Task<IActionResult> AddCover(string covertype)
        {
            string[] cover = covertype.Split(',');
            
            CoverworkerDepartmentViewModel coverworkerDepartmentViewModel = new CoverworkerDepartmentViewModel() { 
                coverDto = new CoverDto() {creatTime=DateTime.UtcNow, Colour= cover[0], Sleeve= cover[1], Size= cover[2], Type= cover[3] },
                departments= (await _coverRepository.GetDepartmentsAsync()).Select(testc=>testc.Name).ToList(),
                workerSizes=(await _coverRepository.GetWorkerSizesAsync()).Select(w=>w.Name).ToList(),

        };
            

            return View(coverworkerDepartmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddCover(CoverDto   coverdto)
        {
            if (!ModelState.IsValid)
            {
                CoverworkerDepartmentViewModel coverworkerDepartmentViewModel = new CoverworkerDepartmentViewModel()
                {
                    coverDto = coverdto,
                    departments = (await _coverRepository.GetDepartmentsAsync()).Select(testc => testc.Name).ToList(),
                    workerSizes = (await _coverRepository.GetWorkerSizesAsync()).Select(w => w.Name).ToList(),

                };
                ModelState.AddModelError(string.Empty, "添加失败");
                return View(coverworkerDepartmentViewModel);
            }
            if (coverdto.Type.Contains("入库"))
            {
                coverdto.workerName = null;
                coverdto.departmentName = null;
            }
            _coverRepository.AddCoverAsync(_mapper.Map<CoverDto, Cover>(coverdto));
            if (coverdto.Type.Contains("出库"))
            {
                var workersize = _mapper.Map<CoverDto, WorkerSize>(coverdto);
                if (!_coverRepository.ExistWorker(coverdto.workerName))
                {

                    _coverRepository.AddWorkerSize(workersize);
                }
                var workersizeupdate = await _coverRepository.GetWorkerSizeByNameAsync(coverdto.workerName);
                workersizeupdate.Size = coverdto.Size;
                
            }
            await _coverRepository.SaveAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
      public IActionResult CoverDetail()
        {
            var coveredaitlparameter = new CoverDedailParameterViewModel()
            {
               coverParameter=new CoverParameter() { StartTime=DateTime.UtcNow,EndTime=DateTime.UtcNow}
               
            };

            return View(coveredaitlparameter);
        }
        public async Task<IActionResult> CoverDetail(CoverParameter coverParameter)
        {
            var covers =await _coverRepository.GetCoversAsync(coverParameter);
            var coveredaitlparameter = new CoverDedailParameterViewModel()
            {
                coverParameter = coverParameter,
                covers = covers
            };

            return View(coveredaitlparameter);

        }
    }
}