using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Colour { get; set; }
        public double TicketValue { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(0,10000 ,ErrorMessage ="必须是一个正整数")]
        [Display(Name = "数量")]
        public int Number { get; set; }
        [Required(ErrorMessage ="{0}不能为空")]
        [Display(Name = "金额")]
        public double SumMoneny { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name ="领用人")]
        public string HappenName { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "类型")]
       
        public string Type { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "支付方式")]
        public string Paypath { get; set; }

    }
}
