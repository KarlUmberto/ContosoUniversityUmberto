﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ContosoUniversityUmberto.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
       
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
