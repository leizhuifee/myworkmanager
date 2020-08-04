using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Dto
{
    public class RoleCreatDto
    {
        [Required(ErrorMessage ="{0}不能位空")]
        [Display(Name ="角色名称")]
        public string name { get; set; }
    }
}
