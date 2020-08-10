using MyWorkManager.Dto;
using MyWorkManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.viewModels
{
    public class CoverworkerDepartmentViewModel
    {
        public List<Department> departments { get; set; }
        public CoverDto coverDto { get; set; }
        public List<WorkerSize> workerSizes { get; set; }
    }
}
