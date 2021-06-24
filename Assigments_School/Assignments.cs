using System;
using System.Collections.Generic;

namespace Assigments_School
{
    class Assignment
    {

        public String title = "";
        public DateTime startDate;
        public DateTime endDate;
        public List<Student> students = new List<Student>();
        public static List<Assignment> assignments = new List<Assignment>();

        public Assignment()
        {
            Assignment.assignments.Add(this);
        }
        ~Assignment()
        {
            Assignment.assignments.Remove(this);
        }

        // Add Assignment
        public static void Add(string title, DateTime startdate, DateTime enddate)
        {
            Console.WriteLine("Importing Assignment.");
            Assignment assignment = new Assignment();
            assignment.title = title;
            assignment.startDate = startdate;
            assignment.endDate = enddate;
            // Save It To DB
                ///
        }

        // Terminal Add Assignment
        public static void TerminalAdd()
        {
            try
            {
                String title = "";
                DateTime enddate = DateTime.Today;
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Assignment.");
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
                Assignment.Add(title, enddate, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
            }
        }

    }
}
