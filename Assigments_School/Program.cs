using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_School
{
    class Program
    {

        public static String db_url = @"localhost";
        public static String db_port = "3306";
        public static String db_name = "AssignmentsSchool";
        public static String db_user_name = "root";//"admin";
        public static String db_user_password = "Platanios719791";
        public static String DB_connection_string = "";

        static void Main(string[] args)
        {
            
            // Connecte to server
            DB_connection_string = $"server={db_url};port={db_port};uid={db_user_name};pwd={db_user_password};database={db_name};" +
                                                $"Charset=utf8;Integrated Security=True";
            MySqlConnection conn = new MySqlConnection(DB_connection_string);
            

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
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "ls":
                            Student.GetAllTerminal();
                            break;
                        case "lt":
                            Trainer.GetAllTerminal();
                            break;
                        case "la":
                            Assignment.GetAllTerminal();
                            break;
                        case "lc":
                            Course.GetAllTerminal();
                            break;
                        case "lsc":
                            Course.GetAllStudentsTerminal();
                            break;
                        case "ltc":
                            Course.GetAllTrainersTerminal();
                            break;
                        case "lac":
                            Course.GetAllAssignmentsTerminal();
                            break;
                        case "las":
                            Student.GetAllAssignmentsTerminal();
                            break;
                        case "lscm":
                            Student.GetAllStudentsThatBelongToMoreThatOneCourse();
                            break;
                        case "lsd":
                            Student.GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek();
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
                            Course.TerminalEdit();
                            break;
                        case "a":
                            Assignment.TerminalEdit();
                            break;
                        case "t":
                            Trainer.TerminalEdit();
                            break;
                        case "s":
                            Student.TerminalEdit();
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
                Console.WriteLine("\n\n");
            }
        }

    }
}
