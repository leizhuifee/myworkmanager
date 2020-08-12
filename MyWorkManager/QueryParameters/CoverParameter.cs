using MyWorkManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.QueryParameters
{
    public class CoverParameter
    {

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public CoverColour Colour { get; set; }
        public CoverSleeve Sleeve { get; set; }
        public CoverSize Size { get; set; }

        public string Type { get; set; }
    }
}
