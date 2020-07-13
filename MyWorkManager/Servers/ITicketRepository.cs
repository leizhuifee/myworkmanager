using MyWorkManager.Models;
using MyWorkManager.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Servers
{
   public  interface ITicketRepository
    {
        IEnumerable<Models.Ticket> GetAllTicekets();
        void AddTickets(Models.Ticket ticket);
        IEnumerable<Models.Ticket> GetAllTiceketsByItems(TicketQueryDetail ticketQuery);
       
    }
}
