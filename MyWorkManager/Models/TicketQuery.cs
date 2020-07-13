using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Models
{
    public class TicketQuery
    {
        
        public DateTime StarTime { get; set; }
        public DateTime endTime { get; set; }
        public string Colour { get; set; }
        public double TicketValue { get; set; }
        
        public string HappenName { get; set; }
        public string Type { get; set; }
        public string Paypath { get; set; }

    }
}
