using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Models
{
    /// <summary>
    /// 员工工作服尺寸表
    /// </summary>
    public class WorkerSize
    {

        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }
       
        public string Size { get; set; }


        public string Department { get; set; }


    }
}
