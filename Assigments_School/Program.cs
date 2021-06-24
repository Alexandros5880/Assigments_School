using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_School
{
    class Program
    {

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Import(i) ? Export(e) ? Quit(q):");
                string choice = Console.ReadLine();

                // Importing
                if (choice.Equals("i") || choice.Equals("Import"))
                {
                    Console.WriteLine("Example for Enter: t  'to import a trainer'.");
                    Console.WriteLine("Import: Course(c) ? Assignment(a) ? Trainer(t) ? Student(s)");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "c":
                            Course.TerminalAdd();
                            break;
                        case "a":
                            Assignment.TerminalAdd();
                            break;
                        case "t":
                            Trainer.TerminalAdd();
                            break;
                        case "s":
                            Student.TerminalAdd();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice.");
                            break;
                    }
                }
                // Exporting
                else if (choice.Equals("e") || choice.Equals("Export"))
                {
                    Console.WriteLine("Exporting mode!");
                    Console.WriteLine(
                        "Enter for Example: ls\n\t"
                            + "(ls)   -->  [ A list of all the students.                                                                    ]\n\t"
                            + "(lt)   -->  [ A list of all the trainers.                                                                    ]\n\t"
                            + "(la)   -->  [ A list of all the assignments.                                                                 ]\n\t"
                            + "(lc)   -->  [ A list of all the courses.                                                                     ]\n\t"
                            + "(lsc)  -->  [ A List of all the students per course.                                                         ]\n\t"
                            + "(ltc)  -->  [ A List of all the trainers per course.                                                         ]\n\t"
                            + "(lac)  -->  [ A List of all the assignments per course.                                                      ]\n\t"
                            + "(las)  -->  [ A List of all the assignments per student.                                                     ]\n\t"
                            + "(lscm) -->  [ A List of all the students that belong to more than one course.                                ]\n\t"
                            + "(lsd)  -->  [ A List of all the students who need to submit one or more assigment on the same calendar week. ]\n\t"
                    );
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "ls":
                            GetAllStudents();
                            break;
                        case "lt":
                            GetAllTrainers();
                            break;
                        case "la":
                            GetAllAssignments();
                            break;
                        case "lc":
                            GetAllCourses();
                            break;
                        case "lsc":
                            GetAllStudentsPerCourse();
                            break;
                        case "ltc":
                            GetAllTrainersPerCourse();
                            break;
                        case "lac":
                            GetAllAssignmentsPerCourse();
                            break;
                        case "las":
                            GetAllAssignmentsPerStudent();
                            break;
                        case "lscm":
                            GetAllStudentsThatBelongToMoreThatOneCourse();
                            break;
                        case "lsd":
                            GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice.");
                            break;
                    }
                }
                // Exit From the program
                else if (choice.Equals("q") || choice.Equals("Quit"))
                {
                    break;
                }
                Console.WriteLine("\n\n");
            }
        }
 



        // Export Functions
        public static void GetAllStudents()
        {
            Console.WriteLine("Exporting All Students.");
        }
        public static void GetAllTrainers()
        {
            Console.WriteLine("Exporting All Trainers.");
        }
        public static void GetAllAssignments()
        {
            Console.WriteLine("Exporting All Assignments.");
        }
        public static void GetAllCourses()
        {
            Console.WriteLine("Exporting All Courses.");
        }
        public static void GetAllStudentsPerCourse()
        {
            Console.WriteLine("Exporting All Students Per Course.");
        }
        public static void GetAllTrainersPerCourse()
        {
            Console.WriteLine("Exporting All Trainers Per Course.");
        }
        public static void GetAllAssignmentsPerCourse()
        {
            Console.WriteLine("Exporting All Assignments Per Course.");
        }
        public static void GetAllAssignmentsPerStudent()
        {
            Console.WriteLine("Exporting All Assignments Per Student.");
        }
        public static void GetAllStudentsThatBelongToMoreThatOneCourse()
        {
            Console.WriteLine("Exporting All Students That Belong To More That One Course.");
        }
        public static void GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek()
        {
            Console.WriteLine("Exporting All Students Who Need To Submit To Assignments On The Same Week.");
        }

    }
}
