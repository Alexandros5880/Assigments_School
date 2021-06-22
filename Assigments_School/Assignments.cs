using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_School
{
    class Assignment
    {

        public String title = "";
        public List<Student> students = new List<Student>();
        public DateTime startDate;
        public DateTime endDate;
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
