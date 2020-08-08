using MyWorkManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Cover>> GetCoversAsync()
        {
            return await _myworkContext.Covers.ToListAsync();
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

       

        public async  Task SaveAsync()
        {
           await _myworkContext.SaveChangesAsync();
        }
    }
}
