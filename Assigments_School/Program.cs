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
                            TerminalImportCourse();
                            break;
                        case "a":
                            TerminalImportAssignment();
                            break;
                        case "t":
                            TerminalImportTrainer();
                            break;
                        case "s":
                            TerminalImportStudent();
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





        // Add Student
        public static void TerminalImportCourse()
        {
            try
            {
                String title = "";
                DateTime enddate = DateTime.Today;
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Course.");
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Give a Title: ");
                    title = Console.ReadLine();
                    if (title.Length > 0)
                    {
                        Console.WriteLine("Set the End Date:");
                        Console.WriteLine($"example: {DateTime.Today.ToString("dd/MM/yyyy")}");
                        enddate = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                        if (enddate > DateTime.Today)
                        {
                            check = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter a Valid End Date!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid Title!\n");
                    }
                }
                // Create The Course Object
                ImportCourse(title, enddate, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
            }
        }
        // Add Assignment
        public static void TerminalImportAssignment()
        {
            try
            {
                String title = "";
                DateTime enddate = DateTime.Today;
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Assignment.");
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Give a Title: ");
                    title = Console.ReadLine();
                    if (title.Length > 0)
                    {
                        Console.WriteLine("Set the End Date:");
                        Console.WriteLine($"example: {DateTime.Today.ToString("dd/MM/yyyy")}");
                        enddate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        if (enddate > DateTime.Today)
                        {
                            check = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter a Valid End Date!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid Title!\n");
                    }
                }
                // Create The Course Object
                ImportAssignment(title, enddate, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
            }
        }
        // Add Trainer
        public static void TerminalImportTrainer()
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
                    if(age > 0)
                    {
                        Console.WriteLine("Gender: Male(m) Femaile(f)");
                        string gen = Console.ReadLine();
                        if(gen == "m" || gen == "f")
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
                ImportTrainer(firstname, lastname, age, gender, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
            }
        }
        // Add Studnt
        public static void TerminalImportStudent()
        {
            try
            {
                String firstname = "";
                String lastname = "";
                int age = 0;
                String gender = "";
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Student.");
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
                ImportStudent(firstname, lastname, age, gender, startdate);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
            }
        }







        // Import Back Functions
        public static void ImportCourse(string title, DateTime enddate, DateTime startdate)
        {
            Console.WriteLine("Importint Cource.");
            Course course = new Course();
            course.title = title;
            course.endDate = enddate;
            course.startDate = startdate;
            // Save It To DB
                ///
        }
        public static void ImportAssignment(string title, DateTime startdate, DateTime enddate)
        {
            Console.WriteLine("Importing Assignment.");
            Assignment assignment = new Assignment();
            assignment.title = title;
            assignment.startDate = startdate;
            assignment.endDate = enddate;
            // Save It To DB
                ///
        }
        public static void ImportTrainer(string firstname, string lastname, int age, string gender, DateTime startdate)
        {
            Console.WriteLine("Importing Trainer.");
            Trainer trainer = new Trainer(firstname, lastname, age, gender, startdate);
            // Save It To DB
                ///
        }
        public static void ImportStudent(string firstname, string lastname, int age, string gender, DateTime startdate)
        {
            Console.WriteLine("Importing Student.");
            Student student = new Student(firstname, lastname, age, gender, startdate);
            // Save It To DB
                ///
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
