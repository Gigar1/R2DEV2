using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class ModuleViewModel
    {
        [Key]
        public int ModuleId { get; set; }
        [Required]
        [Display(Name = "Modulnamn")]
        public string ModuleName { get; set; }
        [Display(Name = "Modulinfo")]
        public string ModuleDescription { get; set; }
    }
}