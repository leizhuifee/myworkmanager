using MyWorkManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.QueryParameters
{
    public class CoverParameter
    {
        public int _pageNumber = 2;
        public int PageNumber { 
            get { return _pageNumber; }
            set
            {
                if (value > 1) _pageNumber = value;//如果查询的不是默认第一页就按实际页数查询
            }
        }
        public int _pageSize = 50;
        public int maxPageSize = 100;
        public int PageSize {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public CoverColour Colour { get; set; }
        public CoverSleeve Sleeve { get; set; }
        public CoverSize Size { get; set; }

        public string Type { get; set; }
    }
}
