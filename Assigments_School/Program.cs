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
                            ImportCourse();
                            break;
                        case "a":
                            ImportAssignment();
                            break;
                        case "t":
                            ImportTrainer();
                            break;
                        case "s":
                            ImportStudent();
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







        // Import Functions
        public static void ImportCourse()
        {
            try
            {
                String title = "";
                DateTime end_date = DateTime.Today;
                DateTime startdate = DateTime.Today;
                List<Trainer> trainers = new List<Trainer>();
                List<Student> students = new List<Student>();
                List<Assignment> assignments = new List<Assignment>();
                Console.WriteLine("Creating New Course.");
                Console.WriteLine("Give a Title: ");
                title = Console.ReadLine();
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Set the End Date:");
                    Console.WriteLine($"example: {DateTime.Today.ToString("dd/MM/yyyy")}");
                    end_date = DateTime.ParseExact(Console.ReadLine(),
                                                                "dd/MM/yyyy",
                                                                null);
                    if (end_date > DateTime.Today)
                    {
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid End Date!");
                    }
                }
                // Add Trainers
                Console.WriteLine("Add Trainers!");
                Boolean check_choice = true;
                while (check_choice)
                {
                    Console.WriteLine("Add Existing Trainers ? y/n");
                    String choice = Console.ReadLine();
                    if (choice.Equals("y"))
                    {
                        check_choice = false;
                        if (Trainer.trainers.Count > 0)
                        {
                            foreach (Trainer tr in Trainer.trainers)
                            {
                                Console.Write($"Add Trainer: {tr.lastname}  {tr.lastname} ? y/n");
                                choice = Console.ReadLine();
                                if (choice.Equals("y"))
                                {
                                    trainers.Add(tr);
                                    Console.WriteLine("Trainer Added to the Course.");
                                }
                                else if (choice.Equals("n"))
                                {

                                }
                                else
                                {
                                    Console.WriteLine("Answare < y > for YES AND < n > for NO");
                                    check_choice = true;
                                }
                            }
                        }
                        else
                        {
                            check_choice = true;
                            Console.WriteLine("No Existing Trainers On System.");
                        }
                    }
                    else if (choice.Equals("n"))
                    {
                        check_choice = false;
                        bool check_choice_tow = true;
                        while (check_choice_tow)
                        {
                            Console.WriteLine("Do you want to create a new Trainer y/n?");
                            choice = Console.ReadLine();
                            if (choice.Equals("y"))
                            {
                                ImportTrainer();
                            }
                            else if (choice.Equals("n"))
                            {
                                check_choice_tow = false;
                            }
                            else
                            {
                                Console.WriteLine("No Traines Added on this Course.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Answare < y > for YES AND < n > for NO");
                    }
                }
                // Add Students
                Console.WriteLine("Add Students!");
                check_choice = true;
                while (check_choice)
                {
                    Console.WriteLine("Add Existing Studets ? y/n");
                    String choice = Console.ReadLine();
                    if (choice.Equals("y"))
                    {
                        check_choice = false;
                        if (Student.students.Count > 0)
                        {
                            foreach (Student st in Student.students)
                            {
                                Console.Write($"Add Student: {st.lastname}  {st.lastname} ? y/n");
                                choice = Console.ReadLine();
                                if (choice.Equals("y"))
                                {
                                    students.Add(st);
                                    Console.WriteLine("Student Added to the Course.");
                                }
                                else if (choice.Equals("n"))
                                {

                                }
                                else
                                {
                                    Console.WriteLine("Answare < y > for YES AND < n > for NO");
                                    check_choice = true;
                                }
                            }
                        }
                        else
                        {
                            check_choice = true;
                            Console.WriteLine("No Existing Students On System.");
                        }
                    }
                    else if (choice.Equals("n"))
                    {
                        check_choice = false;
                        bool check_choice_tow = true;
                        while (check_choice_tow)
                        {
                            Console.WriteLine("Do you want to create a new Student y/n?");
                            choice = Console.ReadLine();
                            if (choice.Equals("y"))
                            {
                                ImportStudent();
                            }
                            else if (choice.Equals("n"))
                            {
                                check_choice_tow = false;
                            }
                            else
                            {
                                Console.WriteLine("No Students Added on this Course.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Answare < y > for YES AND < n > for NO");
                    }
                }
                // Add Assignment
                Console.WriteLine("Add Assignments!");
                check_choice = true;
                while (check_choice)
                {
                    Console.WriteLine("Add Existing Assignments ? y/n");
                    String choice = Console.ReadLine();
                    if (choice.Equals("y"))
                    {
                        check_choice = false;
                        if (Assignment.assignments.Count > 0)
                        {
                            foreach (Assignment asi in Assignment.assignments)
                            {
                                Console.Write($"Add Assignment: {asi.title}  End Date: {asi.endDate} ? y/n");
                                choice = Console.ReadLine();
                                if (choice.Equals("y"))
                                {
                                    assignments.Add(asi);
                                    Console.WriteLine("Assignment Added to the Course.");
                                }
                                else if (choice.Equals("n"))
                                {

                                }
                                else
                                {
                                    Console.WriteLine("Answare < y > for YES AND < n > for NO");
                                    check_choice = true;
                                }
                            }
                        }
                        else
                        {
                            check_choice = true;
                            Console.WriteLine("No Existing Assignments On System.");
                        }
                    }
                    else if (choice.Equals("n"))
                    {
                        check_choice = false;
                        bool check_choice_tow = true;
                        while (check_choice_tow)
                        {
                            Console.WriteLine("Do you want to create a new Assignment y/n?");
                            choice = Console.ReadLine();
                            if (choice.Equals("y"))
                            {
                                ImportAssignment();
                            }
                            else if (choice.Equals("n"))
                            {
                                check_choice_tow = false;
                            }
                            else
                            {
                                Console.WriteLine("No Assignment Added on this Course.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Answare < y > for YES AND < n > for NO");
                    }
                }
                // Create The Course Object
                Course course = new Course();
                course.title = title;
                course.endDate = end_date;
                course.startDate = startdate;
                course.trainers = trainers;
                course.students = students;
                course.assignments = assignments;
                // Save It To DB
                ///
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
            }
        }
        public static void ImportAssignment()
        {
            Console.WriteLine("Imported Assignment.");
        }
        public static void ImportTrainer()
        {
            Console.WriteLine("Imported Trainer.");
        }
        public static void ImportStudent()
        {
            Console.WriteLine("Imported Student.");
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
