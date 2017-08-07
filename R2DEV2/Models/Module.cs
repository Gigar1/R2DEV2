using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        [Required]
        [Display(Name = "Modulnamn")]
        public string ModuleName { get; set; }
        [Display(Name = "Modulinfo")]
        public string ModuleDescription { get; set; }

        public Course Course { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual Module Modules { get; set; }
        //public virtual ICollection<ApplicationUser> Courses { get; set; }
    }
}