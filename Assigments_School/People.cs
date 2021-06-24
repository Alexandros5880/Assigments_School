using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_School
{
    class People
    {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        public String Gender { get; set; }
        public DateTime StartDate { get; set; }
        public static List<People> MyPeople = new List<People>();

        public People(String firstname, String lastname,
                            int age, String gender, DateTime startdate)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;
            this.Gender = gender;
            this.StartDate = startdate;
            People.MyPeople.Add(this);
        }
        ~People()
        {
            People.MyPeople.Remove(this);
        }

        // Get All People On Terminal
        public static bool GetAllTerminal()
        {
            try
            {
                if(People.MyPeople.Count > 0)
                {
                    foreach (People people in People.MyPeople)
                    {
                        Console.WriteLine($"People FirstName: [{people.FirstName}]  LastName: [{people.LastName}]  " +
                            $"Age: [{people.Age}]  Gende: [{people.Gender}]  StartDate: [{people.StartDate}]");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No Peaple Found!");
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
