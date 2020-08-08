using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Models
{
    public class CoverStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Colour { get; set; }
        
       [Required]
        public string Sleeve { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
