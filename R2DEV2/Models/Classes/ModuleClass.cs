using R2DEV2.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




namespace R2DEV2.Models.Classes
{
    public class ModuleClass
    {
        public int Id { get; set; }
        [Display(Name = "Modulnamn")]
        public string Name { get; set; }
        [Display(Name = "Modulinfo")]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Startdatum")]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Slutdatum")]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
        public int CourseClassId { get; set; }

        public virtual ICollection<ActivityClass> Activities { get; set; }
        public virtual CourseClass Course { get; set; }
    }
}