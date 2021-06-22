using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_School
{
    class People
    {

        public String firstname { get; set; }
        public String lastname { get; set; }
        public int age { get; set; }
        public String gender { get; set; }
        public DateTime startdate { get; set; }
        public static List<People> myPeople = new List<People>();

        public People(String firstname, String lastname,
                            int age, String gender, DateTime startdate)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
            this.gender = gender;
            this.startdate = startdate;
            People.myPeople.Add(this);
        }
        ~People()
        {
            People.myPeople.Remove(this);
        }


    }
}
