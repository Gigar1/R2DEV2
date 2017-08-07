using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Förnamn")]
        public string TeacherFirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Efternamn")]
        public string TeacherLastName { get; set; }
        public string TeacherFullName
        {
            get { return TeacherFirstName + " " + TeacherLastName; }
        }

        public virtual ICollection<Course> Courses { get; set; }
        //public virtual ICollection<CourseConnection> CourseConnections { get; set; }
    }
}