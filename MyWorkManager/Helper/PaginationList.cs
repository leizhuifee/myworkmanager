﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Helper
{
    public class PaginationList<T>:List<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public PaginationList(int currentPage,int pageSize,List<T> items)
        {
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            AddRange(items);
        }

        public static async Task< PaginationList<T>> CreateAsync(int currentPage, int pageSize ,IQueryable<T> result)
        {
            var skip = (currentPage - 1) * pageSize;
            result = result.Skip(skip);
            result = result.Take(pageSize);
            var items = await result.ToListAsync();
            return new PaginationList<T>(currentPage, pageSize, items);
        }
    }
}
