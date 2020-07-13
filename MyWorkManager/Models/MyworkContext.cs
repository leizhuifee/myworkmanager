using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyWorkManager.Models
{
    public class MyworkContext:IdentityDbContext<IdentityUser>
    {

        public MyworkContext(DbContextOptions<MyworkContext> options):base(options)
        {

        }

       
        public DbSet<Models.Ticket> Tickets { get; set; }
        public DbSet<Models.Homeimg> Homeimgs { get; set; }
        public  DbSet<Models.Coveruser> Coverusers { get; set; }
    }
}
