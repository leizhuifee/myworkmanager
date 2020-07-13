using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Servers
{
   public interface IHomeimg
    {
        IEnumerable<Models.Homeimg> GetHomeimgs();
        void AddHomeing(Models.Homeimg homeimg);
    }
}
