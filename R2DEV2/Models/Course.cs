using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseStartTime { get; set; }
        public TimeSpan CourseDuration { get; set; }
        public DateTime CourseEndTime { get { return CourseStartTime + CourseDuration; } }

        public virtual Module Module { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        //public Student Student { get; set; }
        

    }
}