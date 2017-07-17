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
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }

        public virtual ICollection<ApplicationUser> Activities { get; set; }
        //public virtual ICollection<ApplicationUser> Courses { get; set; }
    }
}