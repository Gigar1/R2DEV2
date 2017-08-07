using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models.Classes
{
    public class CourseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public virtual ICollection<ApplicationUser> AttendingStudents { get; set; }
        public virtual ICollection<ModuleClass> Modules { get; set; }
    }
}