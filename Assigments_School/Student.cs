using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_School
{
    class Student : People
    {

        public List<Assignment> assignments = new List<Assignment>();
        public List<Course> courses = new List<Course>();
        public static List<Student> students = new List<Student>();

        public Student(String firstname, String lastname,
                            int age, String gender, DateTime startdate) :
                            base(firstname, lastname, age, gender, startdate)
        {
            Student.students.Add(this);
        }
        ~Student()
        {
            Student.students.Remove(this);
        }


    }
}
