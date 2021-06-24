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
        public static List<Student> Students = new List<Student>();

        public Student(String firstname, String lastname,
                            int age, String gender, DateTime startdate) :
                            base(firstname, lastname, age, gender, startdate)
        {
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

        // Get Student
        public static Student Get(string firstname, string lastname, int age, string gender, DateTime startdate)
        {
            try
            {
                IEnumerable<Student> students = from student in Student.Students where
                                                            student.FirstName == firstname &&
                                                            student.LastName == lastname &&
                                                            student.Age == age &&
                                                            student.Gender == gender &&
                                                            student.StartDate == startdate
                                                            select student;
                return (Student) students.ToList().First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n {ex.Message} \n\n");
                return null;
            }
        }

        // Terminal Add Student
        public static Student TerminalAdd()
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
                return Student.Get(firstname, lastname, age, gender, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
                return null;
            }
        }

        // Terminal Edit a Student
        public static void TerminalEdit()
        {

        }

        // Get All Students On Terminal
        public static new bool GetAllTerminal()
        {
            try
            {
                if(Student.Students.Count > 0)
                {
                    foreach (Student student in Student.Students)
                    {
                        Console.WriteLine($"Student FirstName: [{student.FirstName}]  LastName: [{student.LastName}]  " +
                                            $"Age: [{student.Age}]  Gende: [{student.Gender}]  StartDate: [{student.StartDate}]");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No Students Found!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                return false;
            }     
        }

    }
}
