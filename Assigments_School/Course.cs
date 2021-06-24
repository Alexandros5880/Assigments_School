using System;
using System.Collections.Generic;

namespace Assigments_School
{
    class Course
    {

        public String title = "";
        public DateTime startDate;
        public DateTime endDate;
        public List<Trainer> trainers = new List<Trainer>();
        public List<Student> students = new List<Student>();
        public List<Assignment> assignments = new List<Assignment>();
        public static List<Course> courses = new List<Course>();

        public Course()
        {
            Course.courses.Add(this);
        }
        ~Course()
        {
            Course.courses.Remove(this);
        }

        // Add Course
        public static void Add(string title, DateTime enddate, DateTime startdate)
        {
            Console.WriteLine("Importint Cource.");
            Course course = new Course();
            course.title = title;
            course.endDate = enddate;
            course.startDate = startdate;
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

    }
}
