using ContosoUniversityUmberto.Models;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Linq;

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
                new Student() {FirstMidName="Henri Markus",LastName="Jevrson",EnrollmentDate=DateTime.Now},
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

            

            var instructors = new Instructor[]
            {
                new Instructor{FirstMidName = "Jõulu", LastName =
                "Vana", HireDate = DateTime.Parse("1996-03-11")},
                new Instructor{FirstMidName = "Kristjan", LastName =
                "Kessel", HireDate = DateTime.Parse("1996-03-11")},
                new Instructor{FirstMidName = "Limpa", LastName =
                "Kulli", HireDate = DateTime.Parse("1996-03-11")},
                new Instructor{FirstMidName = "Remus", LastName =
                "Luht", HireDate = DateTime.Parse("1996-03-11")}
            };
            var departments = new Department[]
            {
                new Department
                {
                    Name = "PE",
                    Budget = 1,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName == "Kulli").ID
                },
                new Department
                {
                    Name = "Joomerlus",
                    Budget = 1,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName == "Luht").ID
                },
                new Department
                {
                    Name = "StemSubjects",
                    Budget = 1,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName == "Kessel").ID
                },
                new Department
                {
                    Name = "StemSubjects",
                    Budget = 1,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName == "Kessel").ID
                },

            };

            foreach (Department department in departments)
            {
                context.Departments.Add(department);
            }
            context.SaveChanges();
            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment()
                {
                    InstructorID = instructors.Single(i => i.LastName ==    "Vana").ID,
                    Location = "TTHK"
                },
                new OfficeAssignment()
                {
                    InstructorID = instructors.Single(i => i.LastName ==    "Kessel").ID,
                    Location = "TTHK"
                },
                new OfficeAssignment()
                {
                    InstructorID = instructors.Single(i => i.LastName ==    "Luht").ID,
                    Location = "TTHK"
                },

            };

            foreach(OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment
                {
                    CourseID = courses.Single(c => c.Title =="Chemistry").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Vana").ID

                },
                new CourseAssignment
                {
                    CourseID = courses.Single(c => c.Title =="PE").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kessel").ID

                },
                new CourseAssignment
                {
                    CourseID = courses.Single(c => c.Title =="Matemathics").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Luht").ID

                },
            };

            foreach(CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }

            var courses = new Course[];

           
        }
    }
}
