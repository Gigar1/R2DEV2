using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2DEV2.Models.Classes
{
    public class ActivityClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ModuleClassId { get; set; }

        public virtual ModuleClass Module { get; set; }
    }
}