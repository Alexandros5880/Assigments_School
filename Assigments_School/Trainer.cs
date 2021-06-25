using System;
using System.Collections.Generic;
using System.Linq;

namespace Assigments_School
{
    class Trainer : People
    {

        public List<Course> Courses { get; set; }
        public static List<Trainer> Trainers = new List<Trainer>();

        public Trainer(String firstname, String lastname,
                            int age, String gender, DateTime startdate) :
                            base(firstname, lastname, age, gender, startdate)
        {
            this.Courses = new List<Course>();
            Trainer.Trainers.Add(this);
        }
        ~Trainer()
        {
            foreach(Course course in Course.Courses)
            {
                if (course.Trainers.Contains(this))
                {
                    course.Trainers.Remove(this);
                }
            }
            Trainer.Trainers.Remove(this);
        }

        // Add Trainer
        public static void Add(string firstname, string lastname, int age, string gender, DateTime startdate)
        {
            Console.WriteLine("Importing Trainer.");
            Trainer trainer = new Trainer(firstname, lastname, age, gender, startdate);
            // Save It To DB
                ///
        }

        
        // Get Trainer
        public static Trainer Get(string firstname, string lastname, int age, string gender, DateTime startdate)
        {
            try
            {
                IEnumerable<Trainer> traners = from trainer in Trainer.Trainers where
                                               trainer.FirstName == firstname &&
                                               trainer.LastName == lastname &&
                                               trainer.Age == age &&
                                               trainer.Gender == gender &&
                                               trainer.StartDate == startdate
                                               select trainer;

                return (Trainer) traners.ToList().First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n {ex.Message} \n\n");
                return null;
            }
        }
        
        // Terminal Add Trainer
        public static Trainer TerminalAdd()
        {
            try
            {
                String firstname = "";
                String lastname = "";
                int age = 0;
                String gender = "";
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Trainer.");
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
                Trainer.Add(firstname, lastname, age, gender, startdate);
                return Trainer.Get(firstname, lastname, age, gender, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
                return null;
            }
        }

        // Terminal Edit a Trainer
        public static void TerminalEdit()
        {

        }

        // Get All Traines On Terminal
        public static new bool GetAllTerminal()
        {
            try
            {
                if(Trainer.Trainers.Count > 0)
                {
                    int counter = 0;
                    foreach (Trainer trainer in Trainer.Trainers)
                    {
                        Console.WriteLine($"Trainer: Id: [{counter}] FirstName: [{trainer.FirstName}]  LastName: [{trainer.LastName}]  " +
                            $"Age: [{trainer.Age}]  Gende: [{trainer.Gender}]  StartDate: [{trainer.StartDate}]");
                        counter++;
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No Trainer Found!");
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
