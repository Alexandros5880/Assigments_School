using System;
using System.Collections.Generic;
using System.Linq;

namespace Assigments_School
{
    class Trainer : People
    {

        public List<Course> Courses { get; set; }
        public static List<Trainer> Trainers { get; set; }

        public Trainer(String firstname, String lastname,
                            int age, String gender, DateTime startdate) :
                            base(firstname, lastname, age, gender, startdate)
        {
            this.Courses = new List<Course>();
            if(Trainer.Trainers == null)
            {
                Trainer.Trainers = new List<Trainer>();
            }
            Trainer.Trainers.Add(this);
        }
        ~Trainer()
        {
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
            return (Trainer)from trainer in Trainer.Trainers 
                                            where trainer.FirstName == firstname 
                                            where trainer.LastName == lastname 
                                            where trainer.Age == age
                                            where trainer.Gender == gender 
                                            where trainer.StartDate == startdate select trainer;
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
        public static new void GetAllTerminal()
        {
            foreach (Trainer trainer in Trainer.Trainers)
            {
                Console.WriteLine($"Trainer FirstName: [{trainer.FirstName}]  LastName: [{trainer.LastName}]  " +
                    $"Age: [{trainer.Age}]  Gende: [{trainer.Gender}]  StartDate: [{trainer.StartDate}]");
            }
        }


    }
}
