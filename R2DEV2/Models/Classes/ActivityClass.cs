using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models.Classes
{
    public class ActivityClass
    {
        public int Id { get; set; }
        [DisplayName("Aktivitetsnamn")]
        public string Name { get; set; }
        [DisplayName("Aktivitetsinfo")]
        public string Description { get; set; }
        [DisplayName("Startdatum")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [DisplayName("Slutdatum")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
        public int ModuleClassId { get; set; }

        public virtual ModuleClass Module { get; set; }
    }
}