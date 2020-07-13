using MyWorkManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Servers
{
    public class HomeimgRepositorye : IHomeimg
    {
        public MyworkContext _context;
        public HomeimgRepositorye(MyworkContext context)
        {
            _context = context;
        }
        public void AddHomeing(Homeimg homeimg)
        {
            _context.Homeimgs.AddRange(homeimg);
            _context.SaveChanges();
        }

        public IEnumerable<Homeimg> GetHomeimgs()
        {
            return _context.Homeimgs;
        }
    }
}
