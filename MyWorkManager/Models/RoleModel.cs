using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Models
{
    public class RoleModel
    {

    
        public string Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "角色名称")]
        public  string RoleName { get; set; }

    }
}
