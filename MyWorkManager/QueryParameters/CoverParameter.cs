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

        public string  Colour { get; set; }
        public string Sleeve { get; set; }
        public string Size { get; set; }

        public string Type { get; set; }
    }
}
