using MyWorkManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.viewModels
{
    public class TicketQueryDetail
    {

        public IList<TicketQuery> ticketQueries { get; set; }
        public IList<Ticket> tickets { get; set; }
    }
}
