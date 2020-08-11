﻿using MyWorkManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWorkManager.QueryParameters;

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
                result = result.Where(t => t.creatTime >= coverParameter.StartTime && t.creatTime <= coverParameter.EndTime);
                if (!coverParameter.Colour.Contains("0"))
                {
                    result = result.Where(c => c.Colour ==Enum.GetName(typeof(CoverColour), coverParameter.Colour));
                }
                if (!coverParameter.Sleeve.Contains("0"))
                {
                  
                    result = result.Where(c => c.Sleeve == Enum.GetName(typeof(CoverSleeve), coverParameter.Sleeve));
                }
                if (!coverParameter.Size.Contains("0"))
                {
                    result = result.Where(c => c.Size == Enum.GetName(typeof(CoverSize), coverParameter.Size));
                }
                if (!coverParameter.Type.Contains("0"))
                {
                    result = result.Where(c => c.Type ==  coverParameter.Type);
                }
            }
            
             
            return await result.ToListAsync();  
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
