using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWorkManager.Models;

namespace MyWorkManager.Servers
{
   public interface ICoverRepository
   {
       Task<IEnumerable<Cover>> GetCoverByItemsAsync(CoverQueryItems coverQuery);
       Task<IEnumerable<CoverStock>> GetCoverStockByItemsAsync(CoverQueryItems coverQuery);
        Task<bool> AddCoverAsync(Cover cover);
        Task<bool> AddCoverStockAsync(CoverStock coverStock);

        void UpdateCoverStockAsync(CoverStock coverStock);

   }

}
