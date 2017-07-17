using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime ActivityStartTime { get; set; }
        public TimeSpan ActivityDuration { get; set; }
        public DateTime ActivityEndTime { get { return ActivityStartTime + ActivityDuration; } }

        public virtual Activity Activites { get; set; }
    }
}