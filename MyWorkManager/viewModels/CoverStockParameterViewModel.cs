using MyWorkManager.Models;
using MyWorkManager.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.viewModels
{
    public class CoverStockParameterViewModel
    {

        public CoverStockParameterViewModel()
        {
            covers = new List<Cover>();
        }


        public CoverParameter coverParameter { get; set; }
        public IEnumerable<Cover> covers { get; set; }
    }
}
