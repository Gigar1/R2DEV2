using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class CourseClass
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } }

        public virtual ICollection<ApplicationUser> AttendingUsers { get; set; }

    }
}