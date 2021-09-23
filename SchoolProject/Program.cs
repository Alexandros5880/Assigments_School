using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolTerminalHelper school = new SchoolTerminalHelper();
            while (true)
            {
                Console.WriteLine("Import(i) ? Export(e) ? Edit(ed) ? Quit(q):");
                string choice = Console.ReadLine();
                Console.WriteLine("\n");
                // Importing
                if (choice.Equals("i") || choice.Equals("Import"))
                {
                    Console.WriteLine("Example Enter: t  'to import a Trainer'.");
                    Console.WriteLine("Import: Course(c) ? Assignment(a) ? Trainer(t) ? Student(s)");
                    choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "c":
                            school.AddCourse();
                            break;
                        case "a":
                            school.AddAssignment();
                            break;
                        case "t":
                            school.AddTrainer();
                            break;
                        case "s":
                            school.AddStudent();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice.");
                            break;
                    }
                }
                // Exporting
                else if (choice.Equals("e") || choice.Equals("Export"))
                {
                    Console.WriteLine(
                        "Enter for Example: ls\n\n"
                            + "(ls)  -->[ A list of all the students.                                                                                ]\n"
                            + "(lt)  -->[ A list of all the trainers.                                                                                ]\n"
                            + "(la)  -->[ A list of all the assignments.                                                                             ]\n"
                            + "(lc)  -->[ A list of all the courses.                                                                                 ]\n"
                            + "(lsc) -->[ A List of all the students per course.                                                                     ]\n"
                            + "(ltc) -->[ A List of all the trainers per course.                                                                     ]\n"
                            + "(lac) -->[ A List of all the assignments per course.                                                                  ]\n"
                            + "(las) -->[ A List of all the assignments per student.                                                                 ]\n"
                            + "(lasc)-->[ A List of all the assignments pre course and student                                                       ]\n"
                            + "(lscm)-->[ A List of all the students that belong to more than one course.                                            ]\n"
                            + "(lsd) -->[ A List of all the students who need to submit one or more assigment on the same calendar week.             ]\n"
                            + "(lsdc)-->[ A List of all the students who need to submit one or more assigment on the same calendar week on this date.]\n"
                    );
                    choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "ls":
                            school.GetAllStudents();
                            break;
                        case "lt":
                            school.GetAllTrainers();
                            break;
                        case "la":
                            school.GetAllAssignments();
                            break;
                        case "lc":
                            school.GetAllCourses();
                            break;
                        case "lsc":
                            school.GetAllStudentsOnCourse();
                            break;
                        case "ltc":
                            school.GetAllTrainersOnCourse();
                            break;
                        case "lac":
                            school.GetAllAssignmentsPerCourse();
                            break;
                        case "las":
                            school.GetAllAssignmentsPerStudent();
                            break;
                        case "lasc":
                            school.GetAllAssignmentsPerCourseAndStudent();
                            break;
                        case "lscm":
                            school.GetAllStudentsThatBelongToMoreThatOneCourse();
                            break;
                        case "lsd":
                            school.GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek();
                            break;
                        case "lsdc":
                            school.GetAllStudentsWhoNeedToSubmitAssignmentsOnTheSameWeekAsThisDate();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice.");
                            break;
                    }
                }
                // Edit Data
                else if (choice.Equals("ed") || choice.Equals("Edit"))
                {
                    Console.WriteLine("Example Enter: c  'to edit a Course'.");
                    Console.WriteLine("Edit: Course(c) ? Assignment(a) ? Trainer(t) ? Student(s)");
                    choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "c":
                            school.EditCourse();
                            break;
                        case "a":
                            school.EditAssignment();
                            break;
                        case "t":
                            school.EditTrainer();
                            break;
                        case "s":
                            school.EditStudent();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice!");
                            break;
                    }
                }
                // Exit From the program
                else if (choice.Equals("q") || choice.Equals("Quit"))
                {
                    break;
                }
                Console.WriteLine("\n");
            }
        }
    }
}
