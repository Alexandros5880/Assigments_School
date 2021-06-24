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

    }
}
