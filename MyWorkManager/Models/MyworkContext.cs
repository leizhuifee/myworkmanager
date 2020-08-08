using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyWorkManager.Models;

namespace MyWorkManager.Models
{
    public class MyworkContext : IdentityDbContext<IdentityUser>
    {

        public MyworkContext(DbContextOptions<MyworkContext> options) : base(options)
        {

        }


        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Homeimg> Homeimgs { get; set; }
        public DbSet<Cover> Covers { get; set; }
       
        public DbSet<WorkerSize> workerSizes { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
