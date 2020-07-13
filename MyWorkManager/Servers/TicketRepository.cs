using MyWorkManager.Models;
using MyWorkManager.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MyWorkManager.Servers
{
    public class TicketRepository : ITicketRepository
    {
        public MyworkContext _mycontext;
        public TicketRepository(MyworkContext context)
        {
            _mycontext = context;
        }


        public void AddTickets(Ticket ticket)
        {
            _mycontext.Tickets.Add(ticket);
            _mycontext.SaveChanges();
        }

        public IEnumerable<Ticket> GetAllTicekets()
        {
            return _mycontext.Tickets;
        }

        public IEnumerable<Ticket> GetAllTiceketsByItems(TicketQueryDetail ticketQuery)
        {
           var reslut = (IEnumerable < Ticket >) _mycontext.Tickets;
            if (true)
            {
               reslut= reslut.Where(t =>
                    t.CreateTime >= ticketQuery.ticketQueries[0].StarTime &&
                    t.CreateTime <= ticketQuery.ticketQueries[0].endTime);
            }

            if (!ticketQuery.ticketQueries[0].Colour.Contains("全部"))
            {
                reslut = reslut.Where( t=>t.Colour == ticketQuery.ticketQueries[0].Colour);
            }

            if (!ticketQuery.ticketQueries[0].Paypath.Contains("全部"))
            {
                reslut = reslut.Where(t => t.Paypath == ticketQuery.ticketQueries[0].Paypath);
            }
            if (!ticketQuery.ticketQueries[0].Type.Contains("全部"))
            {
                reslut = reslut.Where(t => t.Type == ticketQuery.ticketQueries[0].Type);
            }

            return reslut;
            //if (ticketQuery.ticketQueries[0].Colour.Contains("全部") &&
            //    ticketQuery.ticketQueries[0].Paypath.Contains("全部") && ticketQuery.ticketQueries[0].Type.Contains("全部"))
            //{
            //    return _mycontext.Tickets.Where(t =>
            //        t.CreateTime >= ticketQuery.ticketQueries[0].StarTime &&
            //        t.CreateTime <= ticketQuery.ticketQueries[0].endTime);
            //}
            //else if (!ticketQuery.ticketQueries[0].Colour.Contains("全部") &&
            //         ticketQuery.ticketQueries[0].Paypath.Contains("全部") &&
            //         ticketQuery.ticketQueries[0].Type.Contains("全部"))
            //{
            //    return _mycontext.Tickets.Where(t =>
            //        t.CreateTime >= ticketQuery.ticketQueries[0].StarTime &&
            //        t.CreateTime <= ticketQuery.ticketQueries[0].endTime &&
            //        t.Colour == ticketQuery.ticketQueries[0].Colour);
            //}
            //else if (!ticketQuery.ticketQueries[0].Colour.Contains("全部") &&
            //         !ticketQuery.ticketQueries[0].Paypath.Contains("全部") &&
            //         ticketQuery.ticketQueries[0].Type.Contains("全部"))

            //{
            //    return _mycontext.Tickets.Where(t =>
            //        t.CreateTime >= ticketQuery.ticketQueries[0].StarTime &&
            //        t.CreateTime <= ticketQuery.ticketQueries[0].endTime &&
            //        t.Colour == ticketQuery.ticketQueries[0].Colour &&
            //        t.Paypath == ticketQuery.ticketQueries[0].Paypath);
            //}
            //else if (!ticketQuery.ticketQueries[0].Colour.Contains("全部") &&
            //         !ticketQuery.ticketQueries[0].Paypath.Contains("全部") &&
            //         !ticketQuery.ticketQueries[0].Type.Contains("全部"))

            //{
            //    return _mycontext.Tickets.Where(t =>
            //        t.CreateTime >= ticketQuery.ticketQueries[0].StarTime &&
            //        t.CreateTime <= ticketQuery.ticketQueries[0].endTime &&
            //        t.Colour == ticketQuery.ticketQueries[0].Colour &&
            //        t.Paypath == ticketQuery.ticketQueries[0].Paypath && t.Type == ticketQuery.ticketQueries[0].Type);
            //}
            //else if (ticketQuery.ticketQueries[0].Colour.Contains("全部") &&
            //         !ticketQuery.ticketQueries[0].Paypath.Contains("全部") &&
            //         !ticketQuery.ticketQueries[0].Type.Contains("全部"))
            //{
            //    return _mycontext.Tickets.Where(t =>
            //        t.CreateTime >= ticketQuery.ticketQueries[0].StarTime &&
            //        t.CreateTime <= ticketQuery.ticketQueries[0].endTime
            //        && t.Paypath == ticketQuery.ticketQueries[0].Paypath &&
            //        t.Type == ticketQuery.ticketQueries[0].Type);
            //}
            //else if (ticketQuery.ticketQueries[0].Colour.Contains("全部") &&
            //         ticketQuery.ticketQueries[0].Paypath.Contains("全部") &&
            //         !ticketQuery.ticketQueries[0].Type.Contains("全部"))
            //{
            //    return _mycontext.Tickets.Where(t =>
            //        t.CreateTime >= ticketQuery.ticketQueries[0].StarTime &&
            //        t.CreateTime <= ticketQuery.ticketQueries[0].endTime
            //        && t.Type == ticketQuery.ticketQueries[0].Type);
            //}
            //else
            //{
        ////    return _mycontext.Tickets.Where(t =>
        ////        t.CreateTime >= ticketQuery.ticketQueries[0].StarTime &&
        ////        t.CreateTime <= ticketQuery.ticketQueries[0].endTime &&
        ////        t.Colour == ticketQuery.ticketQueries[0].Colour && t.Paypath == ticketQuery.ticketQueries[0].Paypath);
        ////}



    }
    }
}
