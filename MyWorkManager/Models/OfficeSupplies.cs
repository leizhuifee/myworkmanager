using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Models
{
    public class OfficeSupplies
    {

        public int _number;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Id { get; set; }
        public DateTime CreatTime { get; set; }
          
        public int Month { get; set; }//月份
        public Guid GoodsNameId { get; set; }
        public int Number { get; set; }
            
        public int ControlNuber { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "领用人")]
        public string workerName { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "部门")]
        public string departmentName { get; set; }
    }
}
