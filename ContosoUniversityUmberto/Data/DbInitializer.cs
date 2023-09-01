using ContosoUniversityUmberto.Models;

namespace ContosoUniversityUmberto.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student() {FirstMidName="Remus Markus",LastName="Luht",EnrollmentDate=DateTime.Now},
                new Student() {FirstMidName="Kristjan Georg",LastName="Kessel",EnrollmentDate=DateTime.Now},
                new Student() {FirstMidName="Kenneth-Marcus",LastName="Paljas",EnrollmentDate=DateTime.Now},
                new Student() {FirstMidName="Sten Kristjan",LastName="Uesson",EnrollmentDate=DateTime.Now},
                new Student() {FirstMidName="Peenis",LastName="Peenisson",EnrollmentDate=DateTime.Now},
            };
            context.Students.AddRange(students);
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course() {CourseID=1050,Title="Programmeerimine",Credits=160},
                new Course() {CourseID=3000,Title="Keemia",Credits=160},
                new Course() {CourseID=5345,Title="Matemaatika",Credits=160},
                new Course() {CourseID=1600,Title="Testimine",Credits=160},
                new Course() {CourseID=1234,Title="Riigikaitse",Credits=160},
                new Course() {CourseID=5464,Title="Lõunapaus",Credits=160},
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment() {StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment() {StudentID=5,CourseID=3000,Grade=Grade.A},
                new Enrollment() {StudentID=4,CourseID=1600,Grade=Grade.A},
                new Enrollment() {StudentID=3,CourseID=5345,Grade=Grade.A},
                new Enrollment() {StudentID=4,CourseID=1234,Grade=Grade.F},
                new Enrollment() {StudentID=4,CourseID=1234,Grade=Grade.A},
                new Enrollment() {StudentID=4,CourseID=1234,Grade=Grade.A},
                new Enrollment() {StudentID=4,CourseID=1234,Grade=Grade.A}
            };

            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
