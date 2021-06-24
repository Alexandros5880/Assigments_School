using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_School
{
    class Student : People
    {

        public List<Assignment> Assignments { get; set; }
        public List<Course> Courses { get; set; }
        public static List<Student> Students { get; set; }

        public Student(String firstname, String lastname,
                            int age, String gender, DateTime startdate) :
                            base(firstname, lastname, age, gender, startdate)
        {
            if(Student.Students == null)
            {
                Student.Students = new List<Student>();
            }
            this.Assignments = new List<Assignment>();
            this.Courses = new List<Course>();
            Student.Students.Add(this);
        }
        ~Student()
        {
            Student.Students.Remove(this);
        }

        // Add Student
        public static void Add(string firstname, string lastname, int age, string gender, DateTime startdate)
        {
            Console.WriteLine("Importing Student.");
            Student student = new Student(firstname, lastname, age, gender, startdate);
            // Save It To DB
                ///
        }

        // Terminal Add Student
        public static void TerminalAdd()
        {
            try
            {
                String firstname = "";
                String lastname = "";
                int age = 0;
                String gender = "";
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Student.");
                bool check = true;
                while (check)
                {
                    Console.WriteLine("FirstName: ");
                    firstname = Console.ReadLine();
                    if (firstname.Length > 0)
                    {
                        Console.WriteLine("LastName: ");
                        lastname = Console.ReadLine();
                        if (!(lastname.Length > 0))
                        {
                            Console.WriteLine("Enter a Valid LastName!\n");
                        }
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid FirstName!\n");
                    }
                }
                check = true;
                while (check)
                {
                    Console.WriteLine("Age: ");
                    age = int.Parse(Console.ReadLine());
                    if (age > 0)
                    {
                        Console.WriteLine("Gender: Male(m) Femaile(f)");
                        string gen = Console.ReadLine();
                        if (gen == "m" || gen == "f")
                        {
                            gender = gen;
                            check = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter a Valid Gender!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid Age!\n");
                    }
                }
                // Create The Course Object
                Student.Add(firstname, lastname, age, gender, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
            }
        }

        // Terminal Edit a Student
        public static void TerminalEdit()
        {

        }

        // Get All Students On Terminal
        public static new void GetAllTerminal()
        {
            foreach (Student student in Student.Students)
            {
                Console.WriteLine($"Student FirstName: [{student.FirstName}]  LastName: [{student.LastName}]  " +
                    $"Age: [{student.Age}]  Gende: [{student.Gender}]  StartDate: [{student.StartDate}]");
            }
        }

    }
}
