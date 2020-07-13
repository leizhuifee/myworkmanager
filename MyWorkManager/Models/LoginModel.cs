using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MyWorkManager.Models
{
    public class LoginModel
    {

        public string Id { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name="用户名")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "密码")]
        public string PassWord { get; set; }


    }
}
