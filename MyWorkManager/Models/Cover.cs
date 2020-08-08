using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyWorkManager.Models
{
    
    public class Cover
    {
        public int Id { get; set; }
        public  DateTime creatTime { get; set; }
        
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
        [Display(Name = "款式")]
        public string Sleeve { get; set; }
        /// <summary>
        /// 大小
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "大小")]
        public string Size { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "领用人")]
        public  string  workerName { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "部门")]
        public string departmentName { get; set; }
        public  string Type { get; set; }
        
        [Required]
        [MaxLength(2,ErrorMessage = "每人每次只能领用{1}条")]
        [Display(Name = "领用数量")]
        
        public int Number { get; set; }
        




    }
}
