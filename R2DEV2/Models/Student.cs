using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Förnamn")]
        public string StudentFirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Efternamn")]
        public string StudentLastName { get; set; }
        public string StudentFullName
        {
            get { return StudentFirstName + " " + StudentLastName; }
        }
        public DateTime StudentEnrollmentDate { get; set; }

        //public virtual ICollection<Course> Courses { get; set; }
        public virtual Course Course { get; set; }
    }
}