using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyWorkManager.Servers;
using MyWorkManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyWorkManager.Controllers
{
    public class TicketController : Controller
    {
        public TicketController(Servers.ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public ITicketRepository _ticketRepository;
        
        public IActionResult Index()
        {
          var tickets= _ticketRepository.GetAllTicekets().ToList();
           var s= tickets.GroupBy(t =>new { t.Colour ,t.Type,t.TicketValue}).Select(e=>new { Colour= e.Key.Colour, TicketValue=e.Key.TicketValue , Number=e.Sum(t=>t.Number), SumMoneny = e.Sum(t => t.SumMoneny), Type= e.Key.Type }).ToList();
            List<Ticket> tickesgroup = new List<Ticket>();
            foreach (var item in s)
            {
                if (item.Type=="入库")
                {
                    Ticket ticket = new Ticket();
                    ticket.Colour = item.Colour;
                    ticket.TicketValue = item.TicketValue;
                    ticket.Number = item.Number;
                    ticket.SumMoneny = item.SumMoneny;
                    tickesgroup.Add(ticket);
                }
               
            }
            foreach(var item in s)
            {
                foreach (var i in tickesgroup)
                {
                    if (item.Type == "出库" && i.Colour == item.Colour)
                    {
                        i.Number -= item.Number;
                        i.SumMoneny -= item.SumMoneny;
                    }
                }
               
            }
           
            return View(tickesgroup);
        }

       
    }
}
