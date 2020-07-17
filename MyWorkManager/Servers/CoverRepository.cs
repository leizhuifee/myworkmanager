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

        public async Task<bool> AddCoverAsync(Cover cover)
        {
           await _myworkContext.Covers.AddRangeAsync(cover);
           var result = await _myworkContext.SaveChangesAsync();
           return result > 0 ? true : false;
        }

        public async Task<bool> AddCoverStockAsync(CoverStock coverStock)
        {
            await _myworkContext.CoverStocks.AddRangeAsync(coverStock);
            var result = await _myworkContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<IEnumerable<Cover>> GetCoverByItemsAsync(CoverQueryItems coverQuery)
        {
            return await _myworkContext.Covers.ToListAsync();
        }
        
        public async Task<IEnumerable<CoverStock>> GetCoverStockByItemsAsync(CoverQueryItems coverQuery)
        {
            return await  _myworkContext.CoverStocks.ToListAsync();
        }

        public void UpdateCoverStockAsync(CoverStock coverStock)
        {
             _myworkContext.CoverStocks.UpdateRange(coverStock);
             _myworkContext.SaveChanges();
           
        }
    }
}
