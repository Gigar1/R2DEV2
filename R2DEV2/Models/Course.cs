using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Kursnamn")]
        public string CourseName { get; set; }
        
        public virtual ICollection<Module> Modules { get; set; }
        //public virtual ICollection<Student> Students { get; set; }

        //public Student Student { get; set; }
        //public DateTime CourseStartTime { get; set; }
        //public TimeSpan CourseDuration { get; set; }
        //public DateTime CourseEndTime { get { return CourseStartTime + CourseDuration; } }

    }
}