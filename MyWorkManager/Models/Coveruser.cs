using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyWorkManager.Models
{
    
    public class Coveruser
    {
        public int Id { get; set; }
        
        /// <summary>
        /// 衣领颜色
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "衣领颜色")]
        public string Colour { get; set; }
        /// <summary>
        /// 款式
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "尺寸")]
        public string Sleeve { get; set; }
        /// <summary>
        /// 大小
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "大小")]
        public string Size { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "领用人")]
        public  string Name { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "部门")]
        public string Department { get; set; }

        public int GiveNumber { get; set; }




    }
}
