using System;
using System.Collections.Generic;
using System.Linq;

namespace Assigments_School
{
    class Assignment
    {

        public String Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Student> Students { get; set; }
        public static List<Assignment> Assignments { get; set; }

        public Assignment()
        {
            this.Students = new List<Student>();
            if(Assignment.Assignments == null)
            {
                Assignment.Assignments = new List<Assignment>();
            }
            Assignment.Assignments.Add(this);
        }
        ~Assignment()
        {
            Assignment.Assignments.Remove(this);
        }

        // Add Assignment
        public static void Add(string title, DateTime startdate, DateTime enddate)
        {
            Console.WriteLine("Importing Assignment.");
            Assignment assignment = new Assignment();
            assignment.Title = title;
            assignment.StartDate = startdate;
            assignment.EndDate = enddate;
            // Save It To DB
                ///
        }

        // Get Assignment
        public static Assignment Get(string title, DateTime startdate, DateTime enddate)
        {
            return (Assignment) from assignment in Assignment.Assignments
                                                    where assignment.Title == title
                                                    where assignment.StartDate == startdate
                                                    where assignment.EndDate == enddate
                                                    select assignment;
        }

        // Terminal Add Assignment
        public static Assignment TerminalAdd()
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
                return Assignment.Get(title, enddate, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
                return null;
            }
        }

        // Terminal Edit an Assignment
        public static void TerminalEdit()
        {

        }

        // Get All Assignments On Terminal
        public static void GetAllTerminal()
        {
            foreach (Assignment assignment in Assignment.Assignments)
            {
                Console.WriteLine($"Assignment Title: [{assignment.Title}]  StartDate: [{assignment.StartDate}]  EndDate: [{assignment.EndDate}]");
            }
        }

    }
}
