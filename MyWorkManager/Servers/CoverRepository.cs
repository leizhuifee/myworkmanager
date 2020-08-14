using MyWorkManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWorkManager.QueryParameters;
using MyWorkManager.Helper;

namespace MyWorkManager.Servers
{
    public class CoverRepository : ICoverRepository
    {
        private readonly MyworkContext _myworkContext;

        public CoverRepository(MyworkContext myworkContext)
        {
            _myworkContext = myworkContext;
        }
        #region 添加
        public void AddCoverAsync(Cover cover)
        {
            _myworkContext.Add(cover);
        }

        public void AddDepartmentAsync(Department department)
        {
            _myworkContext.Add(department);
        }

        public void AddWorkerSize(WorkerSize workerSize)
        {
            _myworkContext.Add(workerSize);
        }
        #endregion

        #region 获取所有
        public async Task<IEnumerable<Cover>> GetCoversAsync(CoverParameter coverParameter)
        {
            IQueryable<Cover> result =  _myworkContext.Covers;
                
            if (coverParameter!=null)
            {
                if (coverParameter.StartTime.Year>1000&&coverParameter.EndTime.Year>1000)
                {
                    result = result.Where(t => t.creatTime >= coverParameter.StartTime && t.creatTime <= coverParameter.EndTime);
                }
               
                if (!coverParameter.Colour.ToString().Contains("全部") )
                {
                    result = result.Where(c => c.Colour == coverParameter.Colour);
                }
                if (!coverParameter.Sleeve.ToString().Contains("全部"))
                {
                  
                    result = result.Where(c => c.Sleeve == coverParameter.Sleeve);
                }
                if (!coverParameter.Size.ToString().Contains("全部"))
                {
                    result = result.Where(c => c.Size ==  coverParameter.Size);
                }
               
                if (!coverParameter.Type.Contains("全部"))
                   {
                        result = result.Where(c => c.Type == coverParameter.Type);
                  }
                //return await PaginationList<Cover>.CreateAsync(coverParameter.PageNumber, coverParameter.PageSize, result);
            }
            result = result.Skip(0);
            result = result.Take(2);

            return await result.ToListAsync() ;
          
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _myworkContext.departments.ToListAsync();
        }
        public async Task<IEnumerable<WorkerSize>> GetWorkerSizesAsync()
        {
            return await _myworkContext.workerSizes.ToListAsync();
        }
        #endregion

       
        public async Task<WorkerSize> GetWorkerSizeByNameAsync(string name)
        {
            return await _myworkContext.workerSizes.FirstOrDefaultAsync(w => w.Name == name);
        }
        public bool ExistWorker(string name)
        {
            return   _myworkContext.workerSizes.Any(w=>w.Name.Contains(name));
        }

        public void UpdateWorkerSize(WorkerSize workerSize)
        {
             _myworkContext.Update(workerSize);
        }

        public async  Task SaveAsync()
        {
           await _myworkContext.SaveChangesAsync();
        }
    }
}
