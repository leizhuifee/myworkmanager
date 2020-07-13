using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWorkManager.Models;
using MyWorkManager.Servers;
using MyWorkManager.viewModels;

namespace MyWorkManager.Controllers
{
    public class TicketQueryController : Controller
    {
        public ITicketRepository _ticketRepository;
        public TicketQueryController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public IActionResult Index()
        {
            TicketQueryDetail ticketQueryDetail = new TicketQueryDetail()
            {
                tickets= new List<Ticket>() { new Ticket() { } },
                ticketQueries = null
            };
            return View(ticketQueryDetail);
        }
        public IActionResult TicketQueryDetails(TicketQueryDetail ticketQuery)
        {
           var t = _ticketRepository.GetAllTiceketsByItems(ticketQuery).ToList();
           foreach (var item in t)
           {

               switch (item.Paypath)
               {
                   case "0":
                       item.Paypath = TicketPaypath.微信.ToString();
                       break;
                   case "1":
                       item.Paypath = TicketPaypath.支付宝.ToString();
                       break;
                   case "2":
                       item.Paypath = TicketPaypath.现票.ToString();
                       break;
               }
           }

           ViewBag.number = t.Sum(n => n.Number).ToString();
           ViewBag.summoeny = t.Sum(n => n.SumMoneny);

           TicketQueryDetail ticketQueryDetail = new TicketQueryDetail()
            {
                tickets = t,
                ticketQueries = ticketQuery.ticketQueries
           };
            
          
            return View(ticketQueryDetail);
        }
    }
}
