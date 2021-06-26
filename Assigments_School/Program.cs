﻿using MySqlConnector;
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
        public static String db_user_name = "root";
        public static String db_user_password = "Platanios719791";
        public static String DB_connection_string = "";

        static void Main(string[] args)
        {
            
            // Connecte to server
            DB_connection_string = $"server={db_url};port={db_port};uid={db_user_name};pwd={db_user_password};database={db_name};Charset=utf8;";
            // Integrated Security=True

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
                            //Course.TerminalAdd();
                            break;
                        case "a":
                            //Assignment.TerminalAdd();
                            break;
                        case "t":
                            //Trainer.TerminalAdd();
                            break;
                        case "s":
                            //Student.TerminalAdd();
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
                            GetAllStudentsOnCourse();
                            break;
                        case "ltc":
                            GetAllTrainersOnCourse();
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
                            //Course.TerminalEdit();
                            break;
                        case "a":
                            //Assignment.TerminalEdit();
                            break;
                        case "t":
                            //Trainer.TerminalEdit();
                            break;
                        case "s":
                            //Student.TerminalEdit();
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







        /// <summary>
        /// ///////////////////////////////////////  EXPORTING FUNCTIONS /////////////////////////////////////////////////////////
        /// </summary>
        // Get All Students From DB
        private static void GetAllStudents()
        {
            string sql_query = "SELECT * FROM Students;";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        // Get All Trainers From DB
        private static void GetAllTrainers()
        {
            string sql_query = "SELECT * FROM Trainers;";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        // Get All Assignments FromDB
        private static void GetAllAssignments()
        {
            string sql_query = "SELECT * FROM Assignments;";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Assignment: {reader["Title"]}  {reader["StartDate"]}  " +
                                      $"{reader["EndDate"]}  {reader["CourseTitle"]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        // Get All Courses FromDB
        private static void GetAllCourses()
        {
            string sql_query = "SELECT * FROM Courses;";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Course: {reader["Title"]}  {reader["StartDate"]}  " +
                                      $"{reader["EndDate"]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        // Get All Students Per Course
        private static void GetAllStudentsOnCourse()
        {
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Students stu WHERE (SELECT 1 FROM Courses CU WHERE stu.CourseTitle=cu.Title AND Title='{title}');";
                MySqlConnection connection = new MySqlConnection(DB_connection_string);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    connection.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Student: {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                Console.WriteLine("Please Enter A Valid Title!");
            }
        }

        // Get All Trainers Per Course
        private static void GetAllTrainersOnCourse()
        {
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Students stu WHERE (SELECT 1 FROM Courses CU WHERE stu.CourseTitle=cu.Title AND Title='{title}');";
                MySqlConnection connection = new MySqlConnection(DB_connection_string);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    connection.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Trainer: {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                Console.WriteLine("Please Enter A Valid Title!");
            }
        }

        // Get All Assignments Per Course
        private static void GetAllAssignmentsPerCourse()
        {
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Assignments ass WHERE (SELECT 1 FROM Courses CU WHERE ass.CourseTitle=cu.Title AND Title='{title}');";
                MySqlConnection connection = new MySqlConnection(DB_connection_string);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    connection.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: {reader["Title"]}  {reader["StartDate"]}  " +
                                      $"{reader["EndDate"]}  {reader["CourseTitle"]}");
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                Console.WriteLine("Please Enter A Valid Title!");
            }
        }

        // Get All Assignments Per Student
        private static void GetAllAssignmentsPerStudent()
        {
            Console.Write("Enter Students Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("\n");
            if (email.Length > 0)
            {
                string sql_query = $"SELECT * FROM Assignments ass WHERE (SELECT 1 FROM Students st WHERE ass.Title=st.AssignmentTitle AND Email='{email}');";
                MySqlConnection connection = new MySqlConnection(DB_connection_string);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    connection.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: {reader["Title"]}  {reader["StartDate"]}  " +
                                      $"{reader["EndDate"]}  {reader["CourseTitle"]}");
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                Console.WriteLine("Please Enter A Valid Title!");
            }
        }

        // Get All Students That Belong To More That One Course
        private static void GetAllStudentsThatBelongToMoreThatOneCourse()
        {
            string sql_query = $"SELECT * FROM Students GROUP BY CourseTitle HAVING COUNT(*) > 1;";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        // Get All Students Who Need To Submit AssigNments On The Same Week
        private static void GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek()
        {
            string sql_query = $"SELECT * FROM Students WHERE AssignmentTitle IN (SELECT Title FROM Assignments WHERE WEEK(STR_TO_DATE(EndDate, '%d/%m/%y')) = WEEK(NOW()));";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }











    }
}

