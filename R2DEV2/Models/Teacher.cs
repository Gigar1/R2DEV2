using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2DEV2.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public virtual ICollection<Course> Courses{ get; set; }
    }
}