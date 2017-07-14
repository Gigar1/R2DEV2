using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class ActivityClass
    {
        [Key]
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } }

        public CourseClass CourseClass { get; set; }
    }
}