namespace ContosoUniversityUmberto.Models
{
    public class Student
    {
        public int ID { get; set; }
        public int Lastname { get; set; }
        public int Firstname { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
