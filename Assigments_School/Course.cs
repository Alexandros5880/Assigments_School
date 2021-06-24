using System;
using System.Collections.Generic;

namespace Assigments_School
{
    class Course
    {

        public String Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Student> Students { get; set; }
        public List<Assignment> Assignments { get; set; }
        public static List<Course> Courses { get; set; }

        public Course()
        {
            this.Trainers = new List<Trainer>();
            this.Students = new List<Student>();
            this.Assignments = new List<Assignment>();
            if(Course.Courses == null)
            {
                Course.Courses = new List<Course>();
            }
            Course.Courses.Add(this);
        }
        ~Course()
        {
            Course.Courses.Remove(this);
        }

        // Add Course
        public static void Add(string title, DateTime enddate, DateTime startdate)
        {
            Console.WriteLine("Importint Cource.");
            Course course = new Course();
            course.Title = title;
            course.EndDate = enddate;
            course.StartDate = startdate;
            // Save It To DB
                ///
        }

        // Terminal Add Course
        public static void TerminalAdd()
        {
            try
            {
                String title = "";
                DateTime enddate = DateTime.Today;
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Course.");
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Give a Title: ");
                    title = Console.ReadLine();
                    if (title.Length > 0)
                    {
                        Console.WriteLine("Set the End Date:");
                        Console.WriteLine($"example: {DateTime.Today.ToString("dd/MM/yyyy")}");
                        enddate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        if (enddate > DateTime.Today)
                        {
                            check = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter a Valid End Date!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid Title!\n");
                    }
                }
                // Create The Course Object
                Course.Add(title, enddate, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
            }
        }

        // Terminal Edit a Course
        public static void TerminalEdit()
        {

        }

        // Get All Course On Terminal
        public static void GetAllTerminal()
        {
            foreach(Course course in Course.Courses)
            {
                Console.WriteLine($"Course Title: [{course.Title}]  StartDate: [{course.StartDate}]  EndDate: [{course.EndDate}]");
            }
        }

    }
}
