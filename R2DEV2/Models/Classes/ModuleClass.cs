using R2DEV2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2DEV2.Models.Classes
{
    public class ModuleClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CourseClassId { get; set; }

        public virtual ICollection<ActivityClass> Activities { get; set; }
        public virtual CourseClass Course { get; set; }
    }
}