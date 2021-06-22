using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
