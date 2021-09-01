using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_School
{
    class Program
    {

        public static string db_url = @"localhost";
        public static string db_port = "3306";
        public static string db_server_name = "DESKTOP-QQ55HAA\\SQLEXPRESS";
        public static string db_name = "AssignmentsSchool";
        public static string db_user_name = "root";
        public static string db_user_password = "Platanios719791";
        public static string DB_connection_string = "";

        public static List<string> trainers = new List<string>();
        public static List<string> students = new List<string>();
        public static List<string> courses = new List<string>();
        public static List<string> assignments = new List<string>();

        static void Main(string[] args)
        {
            
            // Connecte to server
            DB_connection_string = $"Server={db_server_name};Database={db_name};Trusted_Connection=True;";

            while (true)
            {
                trainers.Clear();
                students.Clear();
                courses.Clear();
                assignments.Clear();
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
                            AddCourse();
                            break;
                        case "a":
                            AddAssignment();
                            break;
                        case "t":
                            AddTrainer();
                            break;
                        case "s":
                            AddStudent();
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
                        case "lasc":
                            GetAllAssignmentsPerCourseAndStudent();
                            break;
                        case "lscm":
                            GetAllStudentsThatBelongToMoreThatOneCourse();
                            break;
                        case "lsd":
                            GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek();
                            break;
                        case "lsdc":
                            GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeekAsThisDate();
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
                            EditCourse();
                            break;
                        case "a":
                            EditAssignment();
                            break;
                        case "t":
                            EditTrainer();
                            break;
                        case "s":
                            EditStudent();
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

        ///////////////////////////////////////////  IMPORTING FUNCTIONS /////////////////////////////////////////////////////////
        // Import Course
        private static string AddCourse()
        {
            try
            {
                Console.WriteLine("\n");
                string title = "", startdate = "", enddate = "", description = "";
                Console.Write("Title: ");
                title = Console.ReadLine();
                Console.Write("EndDate(27/3/2021): ");
                enddate = Console.ReadLine();
                startdate = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));
                Console.WriteLine("Enter Description: ");
                description = Console.ReadLine();
                if (title.Length > 0 && startdate.Length > 0 && enddate.Length > 0 && description.Length > 0)
                {
                    // Insert Course To Database
                    string sql_query = $"EXEC InsertCourse '{title}', '{startdate}', '{enddate}', '{description}';";
                    SqlConnection connection = new SqlConnection(DB_connection_string);
                    try
                    {
                        SqlCommand cmd = new SqlCommand(sql_query, connection);
                        connection.Open();
                        var reader = cmd.ExecuteNonQuery();
                        Console.WriteLine("\n\nCourse Added\n\n");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Exception: {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }
                    // Add Trainers To Course
                    Console.WriteLine("\n");
                    while (true)
                    {
                        Console.Write("Stop(stop) ? Add New Trainer(new) ? Add Existing Trainer(ex): ");
                        string tr_choice = Console.ReadLine();
                        if (tr_choice.Equals("stop"))
                        {
                            break;
                        }
                        else
                        {
                            string trainer_email = "";
                            switch (tr_choice)
                            {
                                case "new":
                                    trainer_email = AddTrainer();
                                    // Add Trainer To DataBase
                                    sql_query = $"INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) " +
                                                $"VALUES ('{trainer_email}','{title}');";
                                    connection = new SqlConnection(DB_connection_string);
                                    try
                                    {
                                        SqlCommand cmd = new SqlCommand(sql_query, connection);
                                        connection.Open();
                                        var reader = cmd.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine($"Exception: {ex.Message}");
                                    }
                                    finally
                                    {
                                        connection.Close();
                                    }
                                    break;
                                case "ex":
                                    string my_id = "";
                                    Console.WriteLine("Select Trainer By Id(3): ");
                                    GetAllTrainers();
                                    my_id = Console.ReadLine();
                                    trainer_email = trainers[int.Parse(my_id)];
                                    // Add Trainer To DataBase
                                    sql_query = $"INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) " +
                                        $"VALUES ('{trainer_email}','{title}');";
                                    connection = new SqlConnection(DB_connection_string);
                                    try
                                    {
                                        SqlCommand cmd = new SqlCommand(sql_query, connection);
                                        connection.Open();
                                        var reader = cmd.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine($"Exception: {ex.Message}");
                                    }
                                    finally
                                    {
                                        connection.Close();
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter A Valid Choice!");
                                    break;
                            }
                        }
                    }
                    trainers.Clear();
                    // Add Students To Course
                    Console.WriteLine("\n");
                    while (true)
                    {
                        Console.Write("Stop(stop) ? Add New Student(new) ? Add Existing Student(ex): ");
                        string st_choice = Console.ReadLine();
                        if (st_choice.Equals("stop"))
                        {
                            break;
                        }
                        else
                        {
                            string student_email = "";
                            switch (st_choice)
                            {
                                case "new":
                                    student_email = AddStudent();
                                    // Add Trainer To DataBase
                                    sql_query = $"INSERT INTO StudentsCourse (StudentEmail, CourseTitle) " +
                                                $"VALUES ('{student_email}','{title}');";
                                    connection = new SqlConnection(DB_connection_string);
                                    try
                                    {
                                        SqlCommand cmd = new SqlCommand(sql_query, connection);
                                        connection.Open();
                                        var reader = cmd.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine($"Exception: {ex.Message}");
                                    }
                                    finally
                                    {
                                        connection.Close();
                                    }
                                    break;
                                case "ex":
                                    string my_id = "";
                                    Console.WriteLine("Select Student By Id(3): ");
                                    GetAllStudents();
                                    my_id = Console.ReadLine();
                                    student_email = students[int.Parse(my_id)];
                                    // Add Trainer To DataBase
                                    sql_query = $"INSERT INTO StudentsCourse (StudentEmail, CourseTitle) " +
                                        $"VALUES ('{student_email}','{title}');";
                                    connection = new SqlConnection(DB_connection_string);
                                    try
                                    {
                                        SqlCommand cmd = new SqlCommand(sql_query, connection);
                                        connection.Open();
                                        var reader = cmd.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine($"Exception: {ex.Message}");
                                    }
                                    finally
                                    {
                                        connection.Close();
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter A Valid Choice!");
                                    break;
                            }
                        }
                    }
                    students.Clear();
                    return title;
                }
                else
                {
                    Console.WriteLine("Please Fill All Fields!");
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return "";
            }
        }

        // Import Assignments
        private static void AddAssignment()
        {
            try
            {
                string course_title = "";
                Console.WriteLine("\n");
                string title = "", startdate = "", enddate = "", description="";
                Console.Write("Title: ");
                title = Console.ReadLine();
                Console.Write("EndDate(27/3/2021): ");
                enddate = Console.ReadLine();
                startdate = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));
                Console.WriteLine("Enter Description: ");
                description = Console.ReadLine();
                if(title.Length > 0 && startdate.Length > 0 && enddate.Length > 0 && description.Length > 0)
                {
                    string sql_query = $"INSERT INTO Assignments (Title, StartDate, EndDate, Description) " +
                        $"VALUES ('{title}', '{startdate}', '{enddate}', '{description}');";
                    SqlConnection connection = new SqlConnection(DB_connection_string);
                    try
                    {
                        SqlCommand cmd = new SqlCommand(sql_query, connection);
                        connection.Open();
                        var reader = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Exception: {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }
                    // Add Assignment to Course
                    Console.WriteLine("\n");
                    while (true)
                    {
                        Console.Write("Add New Course(new) ? Add Existing Course(ex) ? Stop(stop): ");
                        string ass_course_choice = Console.ReadLine();
                        if (ass_course_choice.Equals("stop"))
                        {
                            break;
                        }
                        else
                        {
                            switch (ass_course_choice)
                            {
                                case "new":
                                    course_title = AddCourse();
                                    if(course_title.Length > 0)
                                    {
                                        // Add To AssignmentsCourse DataBase
                                        string ass_query = $"INSERT INTO AssignmentsCourse (AssignmentTitle, CourseTitle) VALUES ('{title}','{course_title}');";
                                        connection = new SqlConnection(DB_connection_string);
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand(ass_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                        }
                                        finally
                                        {
                                            connection.Close();
                                        }
                                    }
                                    break;
                                case "ex":
                                    Console.WriteLine("Select Course By Id(3): ");
                                    GetAllCourses();
                                    string my_id = Console.ReadLine();
                                    course_title = courses[int.Parse(my_id)];
                                    if (course_title.Length > 0)
                                    {
                                        // Add To DataBase
                                        string ass_query = $"INSERT INTO AssignmentsCourse (AssignmentTitle, CourseTitle) VALUES ('{title}','{course_title}');";
                                        connection = new SqlConnection(DB_connection_string);
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand(ass_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                        }
                                        finally
                                        {
                                            connection.Close();
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter A Valid Choice!");
                                    break;
                            }
                        }
                    }
                    // Get From Course All Students And Select Students To Add Them To Assignment
                    Console.WriteLine("\n");
                    while (true)
                    {
                        Console.Write("Add New Student(new) ? Add Existing Student(ex) ? Stop(stop): ");
                        string ass_course_choice = Console.ReadLine();
                        if (ass_course_choice.Equals("stop"))
                        {
                            break;
                        }
                        else
                        {
                            string student_email = "";
                            switch (ass_course_choice)
                            {
                                case "new":
                                    student_email = AddStudent();
                                    if (student_email.Length > 0)
                                    {
                                        // Add New Stude To This Course
                                        string course_query = $"INSERT INTO StudentCourse (StudentEmail, CourseTitle) VALUES ('{student_email}', '{course_title}')";
                                        connection = new SqlConnection(DB_connection_string);
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand(course_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                        }
                                        finally
                                        {
                                            connection.Close();
                                        }
                                        // Add To AssignmentsStudents On DataBase
                                        string ass_query = $"INSERT INTO AssignmentsStudents (AssignmentTitle, StudentEmail) VALUES ('{title}','{student_email}');";
                                        connection = new SqlConnection(DB_connection_string);
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand(ass_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                        }
                                        finally
                                        {
                                            connection.Close();
                                        }
                                    }
                                    break;
                                case "ex":
                                    Console.WriteLine("Select Student By Id(3): ");
                                    // Get All Students Of This Course
                                    GetAllStudentsOnCourseByTitle(course_title);
                                    // Create Assignment To Student Record
                                    string my_id = Console.ReadLine();
                                    student_email = students[int.Parse(my_id)];
                                    if (student_email.Length > 0)
                                    {
                                        // Add To AssignmentsStudents DataBase
                                        string ass_query = $"INSERT INTO AssignmentsStudents (AssignmentTitle, StudentEmail) VALUES ('{title}','{student_email}');";
                                        connection = new SqlConnection(DB_connection_string);
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand(ass_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                        }
                                        finally
                                        {
                                            connection.Close();
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter A Valid Choice!");
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please Fill All Fields!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        // Import Students
        private static string AddStudent()
        {
            try
            {
                Console.WriteLine("\n");
                string firstname = "", lastname = "", gender = "", startdate = "", email = "", phone = "";
                int age = 0;
                Console.Write("FirstName: ");
                firstname = Console.ReadLine();
                Console.Write("LastName: ");
                lastname = Console.ReadLine();
                Console.Write("Age: ");
                age = int.Parse(Console.ReadLine());
                Console.Write("Gender (Male)?(Female): ");
                gender = Console.ReadLine();
                Console.Write("Email: ");
                email = Console.ReadLine();
                Console.Write("Phone: ");
                phone = Console.ReadLine();
                startdate = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));
                if (firstname.Length > 0 && lastname.Length > 0 && age > 0 &&
                    email.Length > 0 && phone.Length > 0 && gender.Length > 0)
                {
                    string sql_query = $"INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone) " +
                        $"VALUES('{firstname}', '{lastname}', '{age}', '{gender}', '{startdate}', '{email}', '{phone}'); ";
                    SqlConnection connection = new SqlConnection(DB_connection_string);
                    try
                    {
                        SqlCommand cmd = new SqlCommand(sql_query, connection);
                        connection.Open();
                        var reader = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Exception: {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }
                    return email;
                }
                else
                {
                    Console.WriteLine("Please Fill All Fields!");
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return "";
            }
        }

        // Import Trainers
        private static string AddTrainer()
        {
            try
            {
                Console.WriteLine("\n");
                string firstname="", lastname="", gender="", startdate="", email="", phone="";
                int age=0;
                Console.Write("FirstName: ");
                firstname = Console.ReadLine();
                Console.Write("LastName: ");
                lastname = Console.ReadLine();
                Console.Write("Age: ");
                age = int.Parse(Console.ReadLine());
                Console.Write("Gender (Male)?(Female): ");
                gender = Console.ReadLine();
                Console.Write("Email: ");
                email = Console.ReadLine();
                Console.Write("Phone: ");
                phone = Console.ReadLine();
                startdate = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));
                if (firstname.Length > 0 && lastname.Length > 0 && age > 0 && 
                    email.Length > 0 && phone.Length > 0 && gender.Length > 0)
                {
                    string sql_query = $"INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone) " +
                        $"VALUES('{firstname}', '{lastname}', '{age}', '{gender}', '{startdate}', '{email}', '{phone}'); ";
                    SqlConnection connection = new SqlConnection(DB_connection_string);
                    try
                    {
                        SqlCommand cmd = new SqlCommand(sql_query, connection);
                        connection.Open();
                        var reader = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Exception: {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }
                    return email;
                }
                else
                {
                    Console.WriteLine("Please Fill All Fields!");
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return "";
            }
        }



        //////////////////////////////////////////  EDITING RECORDS FUNCTIONS /////////////////////////////////////////////////////////

        // Edit Course
        private static void EditCourse()
        {
            Console.WriteLine("\n");
            GetAllCourses();
            Console.Write("Select Course By Id: ");
            int id = int.Parse(Console.ReadLine());
            string course_title;
            if(id >= 0 && id < courses.Count)
            {
                course_title = courses[id];
                Console.WriteLine("\n");
                while (true)
                {
                    Console.Write("Quit(stop) ? Edit MainImfo(main) ? ADD/REMOVE Students(st) ? ADD/REMOVE Trainers(tr) ? " +
                        "ADD/REMOVE Assignments(ass) ? Delete this Course(del): ");
                    string choice = Console.ReadLine();
                    if (choice.Equals("stop"))
                    {
                        break;
                    }
                    else
                    {
                        switch (choice)
                        {
                            case "main": // Main Imformations
                                Console.WriteLine("\n");
                                Console.Write("Edit Title(t) ? EndDate(date) ? Description(d): ");
                                string e_choice = Console.ReadLine();
                                switch (e_choice)
                                {
                                    case "t":
                                        Console.WriteLine("\n");
                                        Console.Write("Enter new Title: ");
                                        string title = Console.ReadLine();
                                        if(title.Length > 0)
                                        {
                                            // Update DATABASE
                                            string sql_query = $"UPDATE Courses SET Title='{title}' WHERE Title='{course_title}';";
                                            SqlConnection connection = new SqlConnection(DB_connection_string);
                                            try
                                            {
                                                SqlCommand cmd = new SqlCommand(sql_query, connection);
                                                connection.Open();
                                                var reader = cmd.ExecuteNonQuery();
                                            }
                                            catch (SqlException ex)
                                            {
                                                Console.WriteLine($"Exception: {ex.Message}");
                                            }
                                            finally
                                            {
                                                connection.Close();
                                            }
                                        }
                                        break;
                                    case "date":
                                        Console.WriteLine("\n");
                                        Console.Write($"Enter New EndDate Like ({DateTime.Today.ToString("dd/MM/yyy", CultureInfo.CreateSpecificCulture("es-ES"))}): ");
                                        string enddate = Console.ReadLine();
                                        if(enddate.Length > 0)
                                        {
                                            // Update DATABASE
                                            string sql_query = $"UPDATE Courses SET EndDate='{enddate}' WHERE Title='{course_title}';";
                                            SqlConnection connection = new SqlConnection(DB_connection_string);
                                            try
                                            {
                                                SqlCommand cmd = new SqlCommand(sql_query, connection);
                                                connection.Open();
                                                var reader = cmd.ExecuteNonQuery();
                                            }
                                            catch (SqlException ex)
                                            {
                                                Console.WriteLine($"Exception: {ex.Message}");
                                            }
                                            finally
                                            {
                                                connection.Close();
                                            }
                                        }
                                        break;
                                    case "d":
                                        Console.WriteLine("\n");
                                        Console.Write("Enter new Description: ");
                                        string description = Console.ReadLine();
                                        if (description.Length > 0)
                                        {
                                            // Update DATABASE
                                            string sql_query = $"UPDATE Courses SET Description='{description}' WHERE Title='{course_title}';";
                                            SqlConnection connection = new SqlConnection(DB_connection_string);
                                            try
                                            {
                                                SqlCommand cmd = new SqlCommand(sql_query, connection);
                                                connection.Open();
                                                var reader = cmd.ExecuteNonQuery();
                                            }
                                            catch (SqlException ex)
                                            {
                                                Console.WriteLine($"Exception: {ex.Message}");
                                            }
                                            finally
                                            {
                                                connection.Close();
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "st": // Edit Students
                                Console.WriteLine("\n");
                                Console.Write("Add(add) ? Remove(del): ");
                                string st_choice = Console.ReadLine();
                                switch (st_choice)
                                {
                                    case "add":
                                        // Add Students To Course
                                        Console.WriteLine("\n");
                                        while (true)
                                        {
                                            Console.Write("Stop(stop) ? Add New Student(new) ? Add Existing Student(ex): ");
                                            string st_choice_2 = Console.ReadLine();
                                            if (st_choice_2.Equals("stop"))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                string student_email_2;
                                                switch (st_choice_2)
                                                {
                                                    case "new":
                                                        student_email_2 = AddStudent();
                                                        // Add Trainer To DataBase
                                                        string sql_query_2 = $"INSERT INTO StudentsCourse (StudentEmail, CourseTitle) " +
                                                                    $"VALUES ('{student_email_2}','{course_title}');";
                                                        SqlConnection connection_2 = new SqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            SqlCommand cmd = new SqlCommand(sql_query_2, connection_2);
                                                            connection_2.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (SqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_2.Close();
                                                        }
                                                        break;
                                                    case "ex":
                                                        string my_id_2;
                                                        Console.WriteLine("Select Student By Id(3): ");
                                                        GetAllStudents();
                                                        my_id_2 = Console.ReadLine();
                                                        student_email_2 = students[int.Parse(my_id_2)];
                                                        // Add Trainer To DataBase
                                                        sql_query_2 = $"INSERT INTO StudentsCourse (StudentEmail, CourseTitle) " +
                                                            $"VALUES ('{student_email_2}','{course_title}');";
                                                        connection_2 = new SqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            SqlCommand cmd = new SqlCommand(sql_query_2, connection_2);
                                                            connection_2.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (SqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_2.Close();
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Enter A Valid Choice!");
                                                        break;
                                                }
                                            }
                                        }
                                        students.Clear();
                                        break;
                                    case "del":
                                        string my_id;
                                        Console.WriteLine("Select Student By Id(3): ");
                                        GetAllStudentsOnCourseByTitle(course_title);
                                        my_id = Console.ReadLine();
                                        string student_email = students[int.Parse(my_id)];
                                        // Add Trainer To DataBase
                                        string sql_query = $"DELETE FROM StudentsCourse WHERE CourseTitle='{course_title}' AND StudentEmail='{student_email}';";
                                        SqlConnection connection = new SqlConnection(DB_connection_string);
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand(sql_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                        }
                                        finally
                                        {
                                            connection.Close();
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Enter A Valid Choice!");
                                        break;
                                }
                                break;
                            case "tr": // Edit Trainers
                                Console.WriteLine("\n");
                                Console.Write("Add(add) ? Remove(del): ");
                                string tr_choice = Console.ReadLine();
                                switch (tr_choice)
                                {
                                    case "add":
                                        // Add Trainers To Course
                                        Console.WriteLine("\n");
                                        while (true)
                                        {
                                            Console.Write("Stop(stop) ? Add New Trainer(new) ? Add Existing Trainer(ex): ");
                                            string tr_choice_2 = Console.ReadLine();
                                            if (tr_choice_2.Equals("stop"))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                string trainer_email;
                                                switch (tr_choice_2)
                                                {
                                                    case "new":
                                                        trainer_email = AddTrainer();
                                                        // Add Trainer To DataBase
                                                        string sql_query_2 = $"INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) " +
                                                                    $"VALUES ('{trainer_email}','{course_title}');";
                                                        SqlConnection connection_2 = new SqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            SqlCommand cmd = new SqlCommand(sql_query_2, connection_2);
                                                            connection_2.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (SqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_2.Close();
                                                        }
                                                        break;
                                                    case "ex":
                                                        string my_id_3;
                                                        Console.WriteLine("Select Trainer By Id(3): ");
                                                        GetAllTrainers();
                                                        my_id_3 = Console.ReadLine();
                                                        trainer_email = trainers[int.Parse(my_id_3)];
                                                        // Add Trainer To DataBase
                                                        string sql_query_3 = $"INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) " +
                                                            $"VALUES ('{trainer_email}','{course_title}');";
                                                        SqlConnection connection_3 = new SqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            SqlCommand cmd = new SqlCommand(sql_query_3, connection_3);
                                                            connection_3.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (SqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_3.Close();
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Enter A Valid Choice!");
                                                        break;
                                                }
                                            }
                                        }
                                        trainers.Clear();
                                        break;
                                    case "del":
                                        string my_id_2;
                                        Console.WriteLine("Select Trainer By Id(3): ");
                                        GetAllTrainersOnCourse(course_title);
                                        my_id_2 = Console.ReadLine();
                                        string student_email = students[int.Parse(my_id_2)];
                                        // Add Trainer To DataBase
                                        string sql_query = $"DELETE FROM TrainersCourse WHERE CourseTitle='{course_title}' AND StudentEmail='{student_email}';";
                                        SqlConnection connection = new SqlConnection(DB_connection_string);
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand(sql_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                        }
                                        finally
                                        {
                                            connection.Close();
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Enter A Valid Choice!");
                                        break;
                                }
                                break;
                            case "ass": // Edit Assignments
                                // TODO: [EditCourse()]: Edit Assignment Line 995
                                break;
                            case "del": // Delete This Course
                                // TODO: [EditCourse()]: Delete This Course Line 998
                                break;
                            default:
                                Console.WriteLine("Enter A Valid Choice!");
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter A Valid Id!");
            }
        }

        // Edit Assignment
        private static void EditAssignment()
        {
            Console.WriteLine("\n");
            GetAllAssignments();
            Console.Write("Select Assignment By Id: ");
            int id = int.Parse(Console.ReadLine());
            string assignment_title;
            if (id >= 0 && id < assignments.Count)
            {
                assignment_title = assignments[id];
                Console.WriteLine("\n");
                while (true)
                {
                    Console.Write("Quit(stop) ? Edit MainImfo(main) ? ADD/REMOVE Students(st) ? Delete This Assignment(del): ");
                    string choice = Console.ReadLine();
                    if (choice.Equals("stop"))
                    {
                        break;
                    }
                    else
                    {
                        switch (choice)
                        {
                            case "main": // Edit Main Imfo
                                while (true)
                                {
                                    Console.WriteLine("\n");
                                    Console.Write("Quit(stop) ? Title(title) ? EndDate(date) ? Description(de): ");
                                    string ass_choice = Console.ReadLine();
                                    if(ass_choice.Length > 0)
                                    {
                                        if (ass_choice.Equals("stop"))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            switch (ass_choice)
                                            {
                                                case "title": // Edit Title
                                                    Console.Write("Enter New Title: ");
                                                    string title = Console.ReadLine();
                                                    if(title.Length > 0)
                                                    {
                                                        // Enter Title To Database
                                                        string sql_query_0 = $"UPDATE Assignments SET Title='{title}' WHERE Title='{assignment_title}';";
                                                        SqlConnection connection_0 = new SqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            SqlCommand cmd = new SqlCommand(sql_query_0, connection_0);
                                                            connection_0.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (SqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_0.Close();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Enter A Valid Title!");
                                                    }
                                                    break;
                                                case "date":
                                                    Console.Write($"Enter EndDate Like({DateTime.Today.ToString("dd/MM/yyy", CultureInfo.CreateSpecificCulture("es-ES"))}): ");
                                                    string enddate = Console.ReadLine();
                                                    if(enddate.Length > 0)
                                                    {
                                                        // Enter Ende Date To Database
                                                        string sql_query_1 = $"UPDATE Assignments SET EndDate='{enddate}' WHERE Title='{assignment_title}';";
                                                        SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                            connection_1.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (SqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_1.Close();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Enter A Valid Date!");
                                                    }
                                                    break;
                                                case "de":
                                                    Console.Write("Enter New Description: ");
                                                    string description = Console.ReadLine();
                                                    if(description.Length > 0)
                                                    {
                                                        // Enter Description To Database
                                                        string sql_query_2 = $"UPDATE Assignments SET Description='{description}' WHERE Title='{assignment_title}';";
                                                        SqlConnection connection_2 = new SqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            SqlCommand cmd = new SqlCommand(sql_query_2, connection_2);
                                                            connection_2.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (SqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_2.Close();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Enter A Valid Description!");
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                                break;
                            case "st": // Edit Student
                                Console.WriteLine("\n");
                                Console.Write("Add(add) ? Remove(del): ");
                                string st_choice = Console.ReadLine();
                                switch (st_choice)
                                {
                                    case "add": // Add Student To Assignment
                                        Console.WriteLine("\n");
                                        while (true)
                                        {
                                            Console.Write("Stop(stop) ? Add Existing Student(ex): ");
                                            string st_choice_2 = Console.ReadLine();
                                            if (st_choice_2.Equals("stop"))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                string student_email_2;
                                                switch (st_choice_2)
                                                {
                                                    case "ex":
                                                        // Get Parents Course Title;
                                                        string course_title_2 = GetCourseTitleByAssignmentTitle(assignment_title);
                                                        // Select ALL Students On This Course
                                                        string my_id_2;
                                                        Console.WriteLine("Select Student By Id(3): ");
                                                        GetAllStudentsOnCourseByTitle(course_title_2);
                                                        my_id_2 = Console.ReadLine();
                                                        student_email_2 = students[int.Parse(my_id_2)];
                                                        // Add Student To DataBase
                                                        string sql_query_2 = $"INSERT INTO AssignmentsStudents (StudentEmail,AssignmentTitle) " +
                                                            $"VALUES ('{student_email_2}','{assignment_title}');";
                                                        SqlConnection connection_2 = new SqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            SqlCommand cmd = new SqlCommand(sql_query_2, connection_2);
                                                            connection_2.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (SqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_2.Close();
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Enter A Valid Choice!");
                                                        break;
                                                }
                                            }
                                        }
                                        students.Clear();
                                        break;
                                    case "del": // Delete Student From Assignment
                                        // Get Parents Course Title;
                                        string course_title = GetCourseTitleByAssignmentTitle(assignment_title);
                                        // Select ALL Students On This Assignment
                                        string my_id;
                                        Console.WriteLine("Select Student By Id(3): ");
                                        GetAllStudentsOnAssignment(course_title);
                                        my_id = Console.ReadLine();
                                        string student_email = students[int.Parse(my_id)];
                                        // Delete This Student On This Assignment
                                        string sql_query_3 = $"DELETE FROM AssignmentsStudents WHERE AssignmentTitle='{assignment_title}' AND StudentEmail='{student_email}';";
                                        SqlConnection connection_3 = new SqlConnection(DB_connection_string);
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand(sql_query_3, connection_3);
                                            connection_3.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                        }
                                        finally
                                        {
                                            connection_3.Close();
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Enter A Valid Choice!");
                                        break;
                                }
                                break;
                            case "del": // Delete Assignment
                                // Delete All Assignments Courses
                                string sql_query = $"DELETE FROM AssignmentsCourse WHERE AssignmentTitle='{assignment_title}';";
                                SqlConnection connection = new SqlConnection(DB_connection_string);
                                try
                                {
                                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                                    connection.Open();
                                    var reader = cmd.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    connection.Close();
                                }
                                // Delete All Assignments Students
                                sql_query = $"DELETE FROM AssignmentsStudents WHERE AssignmentTitle='{assignment_title}';";
                                connection = new SqlConnection(DB_connection_string);
                                try
                                {
                                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                                    connection.Open();
                                    var reader = cmd.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    connection.Close();
                                }
                                // Delete This Assignment
                                sql_query = $"DELETE FROM Assignments WHERE AssignmentTitle='{assignment_title}';";
                                connection = new SqlConnection(DB_connection_string);
                                try
                                {
                                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                                    connection.Open();
                                    var reader = cmd.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    connection.Close();
                                }
                                Console.WriteLine("Delete Assignment OK.\n");
                                break;
                            default:
                                Console.WriteLine("Enter A Valid Choice!");
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter A Valid Id!");
            }
        }

        // Edit Trainer
        private static void EditTrainer()
        {
            Console.WriteLine("\n");
            GetAllTrainers();
            Console.Write("Select Trainer By Id: ");
            int id = int.Parse(Console.ReadLine());
            string trainer_email;
            if (id >= 0 && id < trainers.Count)
            {
                trainer_email = trainers[id];
                Console.WriteLine("\n");
                while (true)
                {
                    Console.Write("Quit(stop) ? Edit MainImfo(main) ? Delete This Trainer(del): ");
                    string choice = Console.ReadLine();
                    if (choice.Equals("stop"))
                    {
                        break;
                    }
                    else
                    {
                        switch (choice)
                        {
                            case "main":
                                Console.WriteLine("\n");
                                Console.Write("Edit FirstName(fn) ? LastName(ln) ? Age(a) ? Gender(g) ? Email(e) ? Phone(ph): ");
                                string tr_choice_2 = Console.ReadLine();
                                if(tr_choice_2.Length > 0)
                                {
                                    switch (tr_choice_2)
                                    {
                                        case "fn": // Edit FistName
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New FirstName: ");
                                            string firstname = Console.ReadLine();
                                            if(firstname.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Trainers SET FirstName='{firstname}' WHERE Email='{trainer_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid FirstName!");
                                            }
                                            break;
                                        case "ln": // Edit LastName
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New LastName: ");
                                            string lastname = Console.ReadLine();
                                            if (lastname.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Trainers SET LastName='{lastname}' WHERE Email='{trainer_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid LastName!");
                                            }
                                            break;
                                        case "a": // Edit Age
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New Age: ");
                                            string age = Console.ReadLine();
                                            if (age.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Trainers SET Age='{age}' WHERE Email='{trainer_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid Age!");
                                            }
                                            break;
                                        case "g": // Edit Gender
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New Gender(Male/Female): ");
                                            string gender = Console.ReadLine();
                                            if (gender.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Trainers SET Gender='{gender}' WHERE Email='{trainer_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid Gender!");
                                            }
                                            break;
                                        case "e": // Edit Email
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New Email: ");
                                            string email = Console.ReadLine();
                                            if (email.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Trainers SET Email='{email}' WHERE Email='{trainer_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid Email!");
                                            }
                                            break;
                                        case "ph": // Edit Phone
                                            Console.WriteLine("\n");
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New Phone: ");
                                            string phone = Console.ReadLine();
                                            if (phone.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Trainers SET Phone='{phone}' WHERE Email='{trainer_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid Phone!");
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Enter A Valid Choice!");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Enter A Valid Choice!");
                                }
                                break;
                            case "del":
                                // Delete All Trainer Courses With This Trainer
                                string sql_query = $"DELETE FROM TrainersCourse WHERE TrainerEmail='{trainer_email}';";
                                SqlConnection connection = new SqlConnection(DB_connection_string);
                                try
                                {
                                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                                    connection.Open();
                                    var reader = cmd.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    connection.Close();
                                }
                                // Delete This Trainer
                                sql_query = $"DELETE FROM Trainers WHERE Email='{trainer_email}';";
                                connection = new SqlConnection(DB_connection_string);
                                try
                                {
                                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                                    connection.Open();
                                    var reader = cmd.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    connection.Close();
                                }
                                break;
                            default:
                                Console.WriteLine("Enter A Valid Choice!");
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter A Valid Id!");
            }
        }

        // Edit Student
        private static void EditStudent()
        {
            Console.WriteLine("\n");
            GetAllStudents();
            Console.Write("Select Student By Id: ");
            int id = int.Parse(Console.ReadLine());
            string student_email;
            if (id >= 0 && id < students.Count)
            {
                student_email = students[id];
                Console.WriteLine("\n");
                while (true)
                {
                    Console.Write("Quit(stop) ? Edit MainImfo(main) ? Delete This Student(del): ");
                    string choice = Console.ReadLine();
                    if(choice.Equals("stop"))
                    {
                        break;
                    }
                    else
                    {
                        switch (choice)
                        {
                            case "main":
                                Console.WriteLine("\n");
                                Console.Write("Edit FirstName(fn) ? LastName(ln) ? Age(a) ? Gender(g) ? Email(e) ? Phone(ph): ");
                                string tr_choice_2 = Console.ReadLine();
                                if (tr_choice_2.Length > 0)
                                {
                                    switch (tr_choice_2)
                                    {
                                        case "fn": // Edit FistName
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New FirstName: ");
                                            string firstname = Console.ReadLine();
                                            if (firstname.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Students SET FirstName='{firstname}' WHERE Email='{student_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid FirstName!");
                                            }
                                            break;
                                        case "ln": // Edit LastName
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New LastName: ");
                                            string lastname = Console.ReadLine();
                                            if (lastname.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Students SET LastName='{lastname}' WHERE Email='{student_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid LastName!");
                                            }
                                            break;
                                        case "a": // Edit Age
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New Age: ");
                                            string age = Console.ReadLine();
                                            if (age.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Students SET Age='{age}' WHERE Email='{student_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid Age!");
                                            }
                                            break;
                                        case "g": // Edit Gender
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New Gender(Male/Female): ");
                                            string gender = Console.ReadLine();
                                            if (gender.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Students SET Gender='{gender}' WHERE Email='{student_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid Gender!");
                                            }
                                            break;
                                        case "e": // Edit Email
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New Email: ");
                                            string email = Console.ReadLine();
                                            if (email.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Students SET Email='{email}' WHERE Email='{student_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid Email!");
                                            }
                                            break;
                                        case "ph": // Edit Phone
                                            Console.WriteLine("\n");
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New Phone: ");
                                            string phone = Console.ReadLine();
                                            if (phone.Length > 0)
                                            {
                                                // Update FirstName
                                                string sql_query_1 = $"UPDATE Students SET Phone='{phone}' WHERE Email='{student_email}';";
                                                SqlConnection connection_1 = new SqlConnection(DB_connection_string);
                                                try
                                                {
                                                    SqlCommand cmd = new SqlCommand(sql_query_1, connection_1);
                                                    connection_1.Open();
                                                    var reader = cmd.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    connection_1.Close();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter A Valid Phone!");
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Enter A Valid Choice!");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Enter A Valid Choice!");
                                }
                                break;
                            case "del":
                                // Delete All Student Courses With This Student
                                string sql_query = $"DELETE FROM StudentsCourse WHERE StudentEmail='{student_email}';";
                                SqlConnection connection = new SqlConnection(DB_connection_string);
                                try
                                {
                                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                                    connection.Open();
                                    var reader = cmd.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    connection.Close();
                                }
                                // Delete All AssignmentsStudents With This Student
                                sql_query = $"DELETE FROM AssignmentsStudents WHERE StudentEmail='{student_email}';";
                                connection = new SqlConnection(DB_connection_string);
                                try
                                {
                                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                                    connection.Open();
                                    var reader = cmd.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    connection.Close();
                                }
                                // Delete This Trainer
                                sql_query = $"DELETE FROM Students WHERE Email='{student_email}';";
                                connection = new SqlConnection(DB_connection_string);
                                try
                                {
                                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                                    connection.Open();
                                    var reader = cmd.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    connection.Close();
                                }
                                break;
                            default:
                                Console.WriteLine("Enter A Valid Choice!");
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter A Valid Id!");
            }
        }




        //////////////////////////////////////////  EXPORTING FUNCTIONS /////////////////////////////////////////////////////////
        // Get All Students From DB
        private static void GetAllStudents()
        {
            Console.WriteLine("\n");
            string sql_query = "SELECT * FROM Students;";
            SqlConnection connection = new SqlConnection(DB_connection_string);
            try
            {
                SqlCommand cmd = new SqlCommand(sql_query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                students.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: id={counter} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                      $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                      $"{reader["Gender"].ToString().Trim()}");
                    students.Add(reader["Email"].ToString().Trim());
                    counter++;
                }

            }
            catch (SqlException ex)
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
            Console.WriteLine("\n");
            string sql_query = "SELECT * FROM Trainers;";
            SqlConnection connection = new SqlConnection(DB_connection_string);
            try
            {
                SqlCommand cmd = new SqlCommand(sql_query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                trainers.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Trainer: id={counter} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                      $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                      $"{reader["Gender"].ToString().Trim()}");
                    trainers.Add(reader["Email"].ToString());
                    counter++;
                }

            }
            catch (SqlException ex)
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
            Console.WriteLine("\n");
            string sql_query = "SELECT * FROM Assignments;";
            SqlConnection connection = new SqlConnection(DB_connection_string);
            try
            {
                SqlCommand cmd = new SqlCommand(sql_query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    Console.WriteLine($"Assignment: id={counter} {reader["Title"].ToString().Trim()}  " +
                        $"{reader["StartDate"].ToString().Trim()} {reader["EndDate"].ToString().Trim()}");
                    assignments.Add(reader["Title"].ToString().Trim());
                    counter++;
                }

            }
            catch (SqlException ex)
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
            Console.WriteLine("\n");
            string sql_query = "SELECT * FROM Courses;";
            SqlConnection connection = new SqlConnection(DB_connection_string);
            try
            {
                SqlCommand cmd = new SqlCommand(sql_query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                courses.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Course: id={counter} Title: {reader["Title"].ToString().Trim()} " +
                        $"{reader["StartDate"].ToString().Trim()} {reader["EndDate"].ToString().Trim()}");
                    courses.Add(reader["Title"].ToString().Trim());
                    counter++;
                }

            }
            catch (SqlException ex)
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
            Console.WriteLine("\n");
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse WHERE CourseTitle='{title}');";
                SqlConnection connection = new SqlConnection(DB_connection_string);
                try
                {
                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    int counter = 0;
                    students.Clear();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Student: Id={counter} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                      $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                      $"{reader["Gender"].ToString().Trim()}");
                        students.Add(reader["Email"].ToString().Trim());
                        counter++;
                    }

                }
                catch (SqlException ex)
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

        // Get All Students Per Course
        private static void GetAllStudentsOnCourseByTitle(string title)
        {
            string sql_query = $"SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse WHERE CourseTitle='{title}');";
            SqlConnection connection = new SqlConnection(DB_connection_string);
            try
            {
                SqlCommand cmd = new SqlCommand(sql_query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                students.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: Id={counter} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                  $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                  $"{reader["Gender"].ToString().Trim()}");
                    students.Add(reader["Email"].ToString().Trim());
                    counter++;
                }

            }
            catch (SqlException ex)
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

        // Get All Trainers Per Course
        private static void GetAllTrainersOnCourse()
        {
            Console.WriteLine("\n");
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Trainers tr WHERE Email IN (SELECT TrainerEmail FROM TrainersCourse WHERE CourseTitle='{title}');";
                SqlConnection connection = new SqlConnection(DB_connection_string);
                try
                {
                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    int counter = 0;
                    while (reader.Read())
                    {
                        Console.WriteLine($"Trainer: id={counter} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                      $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                      $"{reader["Gender"].ToString().Trim()}");
                        counter++;
                    }

                }
                catch (SqlException ex)
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
        private static void GetAllTrainersOnCourse(string title)
        {
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Trainers tr WHERE Email IN (SELECT TrainerEmail FROM TrainersCourse WHERE CourseTitle='{title}');";
                SqlConnection connection = new SqlConnection(DB_connection_string);
                try
                {
                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    int counter = 0;
                    while (reader.Read())
                    {
                        Console.WriteLine($"Trainer: id={counter} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                      $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                      $"{reader["Gender"].ToString().Trim()}");
                        counter++;
                    }

                }
                catch (SqlException ex)
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
            Console.WriteLine("\n");
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE CourseTitle='{title}');";
                SqlConnection connection = new SqlConnection(DB_connection_string);
                try
                {
                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    assignments.Clear();
                    int counter = 0;
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: id={counter} {reader["Title"].ToString().Trim()}  " +
                            $"{reader["StartDate"].ToString().Trim()}  {reader["EndDate"].ToString().Trim()}");
                        assignments.Add(reader["Title"].ToString().Trim());
                        counter++;
                    }

                }
                catch (SqlException ex)
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

        // Get All Students On Assignment
        private static void GetAllStudentsOnAssignment(string title)
        {
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM AssignmentsStudents WHERE AssignmentTitle='{title}';";
                SqlConnection connection = new SqlConnection(DB_connection_string);
                try
                {
                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    assignments.Clear();
                    int counter = 0;
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: id={counter} {reader["Title"].ToString().Trim()}  " +
                            $"{reader["StartDate"].ToString().Trim()}  {reader["EndDate"].ToString().Trim()}");
                        assignments.Add(reader["Title"].ToString());
                        counter++;
                    }

                }
                catch (SqlException ex)
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

        // Get The Parent Courses Title Of An Assignment
        private static string GetCourseTitleByAssignmentTitle(string title)
        {
            if(title.Length > 0)
            {
                // Get Title Of This Course
                string query = $"SELECT CourseTitle FROM AssignmentsCourse WHERE AssignmentTitle='{title}' LIMIT 0, 1;";
                SqlConnection connection_2 = new SqlConnection(DB_connection_string);
                try
                {
                    SqlCommand cmd = new SqlCommand(query, connection_2);
                    connection_2.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    string course_title = "";
                    while (reader.Read())
                    {
                        course_title = reader["CourseTitle"].ToString().Trim();
                    }
                    return course_title;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    return "";
                }
                finally
                {
                    connection_2.Close();
                }
            }
            else
            {
                return "";
            }
        }

        // Get All Assignments Per Student
        private static void GetAllAssignmentsPerStudent()
        {
            Console.WriteLine("\n");
            Console.Write("Enter Students Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("\n");
            if (email.Length > 0)
            {
                string sql_query = $"SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsStudents WHERE StudentEmail='{email}');";
                SqlConnection connection = new SqlConnection(DB_connection_string);
                try
                {
                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: {reader["Title"].ToString().Trim()}  " +
                            $"{reader["StartDate"].ToString().Trim()}  {reader["EndDate"].ToString().Trim()}");
                    }

                }
                catch (SqlException ex)
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
            Console.WriteLine("\n");
            string sql_query = $"SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse GROUP BY StudentEmail HAVING COUNT(*) > 1);";
            SqlConnection connection = new SqlConnection(DB_connection_string);
            try
            {
                SqlCommand cmd = new SqlCommand(sql_query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                      $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                      $"{reader["Gender"].ToString().Trim()}");
                }

            }
            catch (SqlException ex)
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

        // Get All Assignments Per Course And Student
        private static void GetAllAssignmentsPerCourseAndStudent()
        {
            Console.WriteLine("\n");
            Console.Write("Assignment Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Students Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("\n");
            if (email.Length > 0 && title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE " +
                    $"CourseTitle='{title}') AND Title IN(SELECT AssignmentTitle FROM AssignmentsStudents WHERE StudentEmail = '{email}'); ";
                SqlConnection connection = new SqlConnection(DB_connection_string);
                try
                {
                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: {reader["Title"].ToString().Trim()}  " +
                            $"{reader["StartDate"].ToString().Trim()}  {reader["EndDate"].ToString().Trim()}");
                    }

                }
                catch (SqlException ex)
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

        // Get All Students Who Need To Submit AssigNments On The Same Week
        private static void GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek()
        {
            Console.WriteLine("\n");
            string sql_query = $"SELECT * FROM Students WHERE Email IN (SELECT StudentEmail FROM AssignmentsStudents " +
                $"WHERE AssignmentTitle IN (SELECT Title FROM Assignments WHERE WEEK(STR_TO_DATE(EndDate, '%d/%m/%y')) = WEEK(NOW())));";
            SqlConnection connection = new SqlConnection(DB_connection_string);
            try
            {
                SqlCommand cmd = new SqlCommand(sql_query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                      $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                      $"{reader["Gender"].ToString().Trim()}");
                }

            }
            catch (SqlException ex)
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

        // Get All Students Who Need To Submeet An Assignment On The Same Week As The Date
        private static void GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeekAsThisDate()
        {
            Console.WriteLine("\n");
            Console.Write($"Enter A Date Like({DateTime.Today.ToString("dd/MM/yyy", CultureInfo.CreateSpecificCulture("es-ES"))}): ");
            string date = Console.ReadLine();
            Console.WriteLine("\n");
            if(date.Length > 0)
            {
                string sql_query = $"SELECT * FROM Students WHERE Email IN (SELECT StudentEmail FROM AssignmentsStudents " +
                    $"WHERE AssignmentTitle IN (SELECT Title FROM Assignments " +
                    $"WHERE WEEK(STR_TO_DATE(EndDate, '%d/%m/%y')) = WEEK(STR_TO_DATE('{date}', '%d/%m/%y'))));";
                SqlConnection connection = new SqlConnection(DB_connection_string);
                try
                {
                    SqlCommand cmd = new SqlCommand(sql_query, connection);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Student: {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                          $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                          $"{reader["Gender"].ToString().Trim()}");
                    }

                }
                catch (SqlException ex)
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
}

