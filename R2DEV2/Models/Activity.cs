using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        [Required]
        [Display(Name = "Activitetsnamn")]
        public string ActivityName { get; set; }
        [Required]
        [Display(Name = "Activitetsinfo")]
        public string ActivityDescription { get; set; }
        [Required]
        [Display(Name = "Starttid")]
        public DateTime ActivityStartTime { get; set; }
        [Required]
        [Display(Name = "Tidslängd")]
        public TimeSpan ActivityDuration { get; set; }
        public DateTime ActivityEndTime { get { return ActivityStartTime + ActivityDuration; } }

        public virtual Module Modules { get; set; }
    }
}