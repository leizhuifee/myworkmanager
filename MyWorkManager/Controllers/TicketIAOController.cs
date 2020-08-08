using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWorkManager.Models;

namespace MyWorkManager.Controllers
{
    public class TicketIAOController : Controller
    {

        public Servers.ITicketRepository _ticketRepository;
        public TicketIAOController(Servers.ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index(string state)
        {
            Ticket ticket = new Ticket();
            if (state!=null)
            {
                string[] s = state.Split(',');
                if (s[0] == "黄色")
                {
                    ticket.Colour = "黄色";
                    ticket.TicketValue = 0.5;
                    ticket.Type = s[1];

                }
                if (s[0] == "红色")
                {
                    ticket.Colour = "红色";
                    ticket.TicketValue = 1;
                    ticket.Type = s[1];

                }
            }
            

            return View(ticket);
        }
        //[HttpPost]
        //public  IActionResult Add(Ticket ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ticket.CreateTime = DateTime.Now;
        //        _ticketRepository.AddTickets(ticket);
        //        return RedirectToAction("Index", "Ticket");
        //    }
        //    else
        //    {
        //        string state = ticket.Colour + "," + ticket.Type;
        //        ModelState.AddModelError(string.Empty, "不能空值");
        //        return RedirectToRoute(new { Controller= "TicketIAO",Action="Index", state = state });

        //    };
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Index(Ticket ticket)
        {
            if (ModelState.IsValid&&ticket.Paypath!="请选择")
            {
                ticket.CreateTime = DateTime.Now;
                _ticketRepository.AddTickets(ticket);
                return RedirectToAction("Index", "Ticket");
            }
            else
            {
                
                ModelState.AddModelError(string.Empty, "不能空值");
                return View(ticket);

            };
        }
}
}
