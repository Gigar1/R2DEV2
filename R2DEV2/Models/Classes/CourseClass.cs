using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R2DEV2.Models.Classes
{
    public class CourseClass
    {
        public int Id { get; set; }
        [Display(Name = "Kursnamn")]
        public string Name { get; set; }
        [Display(Name = "Kursinfo")]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Startdatum")]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Slutdatum")]
        public DateTime EndTime { get; set; }

        public virtual ICollection<ApplicationUser> AttendingStudents { get; set; }
        public virtual ICollection<ModuleClass> Modules { get; set; }
    }
}