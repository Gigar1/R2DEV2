using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2DEV2.Models.Classes
{
    public class CourseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } }
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> AttendingStudents { get; set; }
    }
}