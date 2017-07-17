using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        //public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}