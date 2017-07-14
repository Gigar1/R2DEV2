using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class ModuleClass
    {
        [Key]
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }

        public CourseClass CourseClass { get; set; }

        //public virtual ICollection<ModuleClass> Activities { get; set; }
        //public virtual ICollection<ApplicationUser> Courses { get; set; }
    }
}