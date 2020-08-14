using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWorkManager.Helper;
using MyWorkManager.Models;
using MyWorkManager.QueryParameters;

namespace MyWorkManager.Servers
{
   public interface ICoverRepository
   {
        Task<IEnumerable<WorkerSize>>  GetWorkerSizesAsync();//获取所有的员工尺寸对应表
        Task<IEnumerable<Department>> GetDepartmentsAsync();//获取所有的部门
        Task<IEnumerable<Cover>> GetCoversAsync(CoverParameter coverParameter);//获取所有领用信息
        Task<WorkerSize> GetWorkerSizeByNameAsync(string name);//根据员工姓名获取员工对应信息

        bool ExistWorker(string name);
        void UpdateWorkerSize(WorkerSize workerSize);

        void AddCoverAsync(Cover cover); //添加领用信息
        void AddDepartmentAsync(Department department); //添加部门
        void AddWorkerSize(WorkerSize workerSize);

      

        Task SaveAsync();

   }

}
