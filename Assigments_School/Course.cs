using System;
using System.Collections.Generic;
using System.Linq;

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
        public static List<Course> Courses = new List<Course>();

        public Course()
        {
            this.Trainers = new List<Trainer>();
            this.Students = new List<Student>();
            this.Assignments = new List<Assignment>();
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

        // Get Course
        public static Course Get(string title)
        {
            try
            {
                IEnumerable<Course> courses = from course in Course.Courses
                                       where course.Title == title
                                       select course;
                
                return (Course)courses.ToList().First();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\n\n {ex.Message} \n\n");
                return null;
            }   
        }

        // Terminal Add Course
        public static Course TerminalAdd()
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
                return Course.Get(title);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
                return null;
            }
        }

        // Terminal Edit a Course
        public static void TerminalEdit()
        {
            // Select Course
            Console.Write("Please Enter Course Title:");
            String title = Console.ReadLine();
            Course course = Course.Get(title);
            // Select What to Edit On Course
            Console.WriteLine("Add: Trainers(t) ? Students(s) ? Assignments(a) ? Edit Main Imfo(m)");
            String choice = Console.ReadLine();
            switch(choice)
            {
                case "t": // Edit Trainers
                    Console.WriteLine("Add Trainer(a) ? Remove Trainer(r)");
                    String choice_t_ar = Console.ReadLine();
                    Trainer trainer;
                    switch (choice_t_ar)
                    {
                        case "a": // Add Trainer
                            Console.WriteLine("Add Existing Trainer: (ex) ? Add New Trainer: (new)");
                            String choice_t = Console.ReadLine();
                            switch (choice_t)
                            {
                                case "ex":
                                    if (Trainer.GetAllTerminal())
                                    {
                                        Console.WriteLine("Select Trainer By Id:");
                                        int id = int.Parse(Console.ReadLine());
                                        trainer = Trainer.Trainers[id];
                                    }
                                    else
                                    {
                                        trainer = null;
                                    }
                                    break;
                                case "new":
                                    trainer = Trainer.TerminalAdd();
                                    break;
                                default:
                                    Console.WriteLine("Enter a Valid Choice!");
                                    trainer = null;
                                    break;
                            }
                            if (trainer != null)
                            {
                                course.Trainers.Add(trainer);
                            }
                            else
                            {
                                Console.WriteLine("Please Try Again!");
                            }
                            break;
                        case "r": // Remove Trainer
                            if (course.Trainers.Count > 0)
                            {
                                int count = 0;
                                foreach(Trainer train in course.Trainers)
                                {
                                    Console.WriteLine($"Trainer: Id: [{count}] FirstName: [{train.FirstName}]  LastName: [{train.LastName}]  " +
                                                                            $"Age: [{train.Age}]  Gende: [{train.Gender}]  StartDate: [{train.StartDate}]");
                                    count++;
                                }
                                Console.WriteLine("Select Trainer By Id:");
                                int id = int.Parse(Console.ReadLine());
                                trainer = course.Trainers[id];
                                Console.WriteLine($"Course Thrainers: {course.Trainers.Count}");
                                Console.WriteLine($"Removing Trainer: {trainer.FirstName} {trainer.LastName}");
                                course.Trainers.Remove(trainer);
                                Console.WriteLine($"Course Thrainers: {course.Trainers.Count}");
                            }
                            else
                            {
                                Console.WriteLine("No Trainers Exists in this Course!");
                            }
                            break;
                    }
                    break;
                case "s": // Edit Students
                    break;
                case "a": // Edit Assignments
                    break;
                case "m": // Edit Main Imfo
                    break;
                default:
                    Console.WriteLine("Enter a Valid Choice!");
                    break;

            }
        }

        // Get All Course On Terminal
        public static new bool GetAllTerminal()
        {
            try
            {
                if(Course.Courses.Count > 0)
                {
                    foreach (Course course in Course.Courses)
                    {
                        Console.WriteLine($"Course Title: [{course.Title}]  StartDate: [{course.StartDate}]  EndDate: [{course.EndDate}]");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No Courses Found!");
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
