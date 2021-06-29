using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static List<string> trainers = new List<string>();
        public static List<string> students = new List<string>();
        public static List<string> courses = new List<string>();
        public static List<string> assignments = new List<string>();

        static void Main(string[] args)
        {
            
            // Connecte to server
            DB_connection_string = $"server={db_url};port={db_port};uid={db_user_name};pwd={db_user_password};database={db_name};Charset=utf8;";
            // Integrated Security=True

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
                    string sql_query = $"INSERT INTO Courses (Title, StartDate, EndDate, Description) " +
                        $"VALUES ('{title}', '{startdate}', '{enddate}', '{description}');";
                    MySqlConnection connection = new MySqlConnection(DB_connection_string);
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                        connection.Open();
                        var reader = cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
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
                                    connection = new MySqlConnection(DB_connection_string);
                                    try
                                    {
                                        MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                                        connection.Open();
                                        var reader = cmd.ExecuteNonQuery();
                                    }
                                    catch (MySqlException ex)
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
                                    connection = new MySqlConnection(DB_connection_string);
                                    try
                                    {
                                        MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                                        connection.Open();
                                        var reader = cmd.ExecuteNonQuery();
                                    }
                                    catch (MySqlException ex)
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
                                    connection = new MySqlConnection(DB_connection_string);
                                    try
                                    {
                                        MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                                        connection.Open();
                                        var reader = cmd.ExecuteNonQuery();
                                    }
                                    catch (MySqlException ex)
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
                                    connection = new MySqlConnection(DB_connection_string);
                                    try
                                    {
                                        MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                                        connection.Open();
                                        var reader = cmd.ExecuteNonQuery();
                                    }
                                    catch (MySqlException ex)
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
                    MySqlConnection connection = new MySqlConnection(DB_connection_string);
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                        connection.Open();
                        var reader = cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
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
                                        connection = new MySqlConnection(DB_connection_string);
                                        try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(ass_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (MySqlException ex)
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
                                        connection = new MySqlConnection(DB_connection_string);
                                        try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(ass_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (MySqlException ex)
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
                                        connection = new MySqlConnection(DB_connection_string);
                                        try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(course_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (MySqlException ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                        }
                                        finally
                                        {
                                            connection.Close();
                                        }
                                        // Add To AssignmentsStudents On DataBase
                                        string ass_query = $"INSERT INTO AssignmentsStudents (AssignmentTitle, StudentEmail) VALUES ('{title}','{student_email}');";
                                        connection = new MySqlConnection(DB_connection_string);
                                        try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(ass_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (MySqlException ex)
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
                                        connection = new MySqlConnection(DB_connection_string);
                                        try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(ass_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (MySqlException ex)
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
                    MySqlConnection connection = new MySqlConnection(DB_connection_string);
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                        connection.Open();
                        var reader = cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
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
                    MySqlConnection connection = new MySqlConnection(DB_connection_string);
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                        connection.Open();
                        var reader = cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
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
            string course_title = "";
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
                                            MySqlConnection connection = new MySqlConnection(DB_connection_string);
                                            try
                                            {
                                                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                                                connection.Open();
                                                var reader = cmd.ExecuteNonQuery();
                                            }
                                            catch (MySqlException ex)
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
                                            MySqlConnection connection = new MySqlConnection(DB_connection_string);
                                            try
                                            {
                                                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                                                connection.Open();
                                                var reader = cmd.ExecuteNonQuery();
                                            }
                                            catch (MySqlException ex)
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
                                            MySqlConnection connection = new MySqlConnection(DB_connection_string);
                                            try
                                            {
                                                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                                                connection.Open();
                                                var reader = cmd.ExecuteNonQuery();
                                            }
                                            catch (MySqlException ex)
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
                                                string student_email_2 = "";
                                                switch (st_choice_2)
                                                {
                                                    case "new":
                                                        student_email_2 = AddStudent();
                                                        // Add Trainer To DataBase
                                                        string sql_query_2 = $"INSERT INTO StudentsCourse (StudentEmail, CourseTitle) " +
                                                                    $"VALUES ('{student_email_2}','{course_title}');";
                                                        MySqlConnection connection_2 = new MySqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            MySqlCommand cmd = new MySqlCommand(sql_query_2, connection_2);
                                                            connection_2.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (MySqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_2.Close();
                                                        }
                                                        break;
                                                    case "ex":
                                                        string my_id_2 = "";
                                                        Console.WriteLine("Select Student By Id(3): ");
                                                        GetAllStudents();
                                                        my_id_2 = Console.ReadLine();
                                                        student_email_2 = students[int.Parse(my_id_2)];
                                                        // Add Trainer To DataBase
                                                        sql_query_2 = $"INSERT INTO StudentsCourse (StudentEmail, CourseTitle) " +
                                                            $"VALUES ('{student_email_2}','{course_title}');";
                                                        connection_2 = new MySqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            MySqlCommand cmd = new MySqlCommand(sql_query_2, connection_2);
                                                            connection_2.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (MySqlException ex)
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
                                        string my_id = "";
                                        Console.WriteLine("Select Student By Id(3): ");
                                        GetAllStudentsOnCourseByTitle(course_title);
                                        my_id = Console.ReadLine();
                                        string student_email = students[int.Parse(my_id)];
                                        // Add Trainer To DataBase
                                        string sql_query = $"DELETE FROM StudentsCourse WHERE CourseTitle='{course_title}' AND StudentEmail='{student_email}';";
                                        MySqlConnection connection = new MySqlConnection(DB_connection_string);
                                        try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (MySqlException ex)
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
                                                string trainer_email = "";
                                                switch (tr_choice_2)
                                                {
                                                    case "new":
                                                        trainer_email = AddTrainer();
                                                        // Add Trainer To DataBase
                                                        string sql_query_2 = $"INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) " +
                                                                    $"VALUES ('{trainer_email}','{course_title}');";
                                                        MySqlConnection connection_2 = new MySqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            MySqlCommand cmd = new MySqlCommand(sql_query_2, connection_2);
                                                            connection_2.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (MySqlException ex)
                                                        {
                                                            Console.WriteLine($"Exception: {ex.Message}");
                                                        }
                                                        finally
                                                        {
                                                            connection_2.Close();
                                                        }
                                                        break;
                                                    case "ex":
                                                        string my_id_3 = "";
                                                        Console.WriteLine("Select Trainer By Id(3): ");
                                                        GetAllTrainers();
                                                        my_id_3 = Console.ReadLine();
                                                        trainer_email = trainers[int.Parse(my_id_3)];
                                                        // Add Trainer To DataBase
                                                        string sql_query_3 = $"INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) " +
                                                            $"VALUES ('{trainer_email}','{course_title}');";
                                                        MySqlConnection connection_3 = new MySqlConnection(DB_connection_string);
                                                        try
                                                        {
                                                            MySqlCommand cmd = new MySqlCommand(sql_query_3, connection_3);
                                                            connection_3.Open();
                                                            var reader = cmd.ExecuteNonQuery();
                                                        }
                                                        catch (MySqlException ex)
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
                                        string my_id_2 = "";
                                        Console.WriteLine("Select Trainer By Id(3): ");
                                        GetAllTrainersOnCourse(course_title);
                                        my_id_2 = Console.ReadLine();
                                        string student_email = students[int.Parse(my_id_2)];
                                        // Add Trainer To DataBase
                                        string sql_query = $"DELETE FROM TrainersCourse WHERE CourseTitle='{course_title}' AND StudentEmail='{student_email}';";
                                        MySqlConnection connection = new MySqlConnection(DB_connection_string);
                                        try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                                            connection.Open();
                                            var reader = cmd.ExecuteNonQuery();
                                        }
                                        catch (MySqlException ex)
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
                                break;
                            case "del": // Delete This Course
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
            string assignment_title = "";
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
                            case "main":
                                break;
                            case "st":
                                break;
                            case "del":
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
            string trainer_email = "";
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
                                break;
                            case "del":
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
            string student_email = "";
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
                                break;
                            case "del":
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
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                students.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: id={counter} {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                    students.Add(reader["Email"].ToString());
                    counter++;
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
            Console.WriteLine("\n");
            string sql_query = "SELECT * FROM Trainers;";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                trainers.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Trainer: id={counter} {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                    trainers.Add(reader["Email"].ToString());
                    counter++;
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
            Console.WriteLine("\n");
            string sql_query = "SELECT * FROM Assignments;";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    Console.WriteLine($"Assignment: id={counter} {reader["Title"]}  {reader["StartDate"]} {reader["EndDate"]}");
                    assignments.Add(reader["Title"].ToString());
                    counter++;
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
            Console.WriteLine("\n");
            string sql_query = "SELECT * FROM Courses;";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                courses.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Course: id={counter} Title: {reader["Title"]}  {reader["StartDate"]}  " +
                                      $"{reader["EndDate"]}");
                    courses.Add(reader["Title"].ToString());
                    counter++;
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
            Console.WriteLine("\n");
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse WHERE CourseTitle='{title}');";
                MySqlConnection connection = new MySqlConnection(DB_connection_string);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    connection.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    int counter = 0;
                    students.Clear();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Student: Id={counter} {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                        students.Add(reader["Email"].ToString());
                        counter++;
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

        // Get All Students Per Course
        private static void GetAllStudentsOnCourseByTitle(string title)
        {
            string sql_query = $"SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse WHERE CourseTitle='{title}');";
            MySqlConnection connection = new MySqlConnection(DB_connection_string);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                students.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: Id={counter} {reader["FirstName"]}  {reader["LastName"]}  " +
                                  $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                  $"{reader["Gender"]}");
                    students.Add(reader["Email"].ToString());
                    counter++;
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
                MySqlConnection connection = new MySqlConnection(DB_connection_string);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    connection.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    int counter = 0;
                    while (reader.Read())
                    {
                        Console.WriteLine($"Trainer: id={counter} {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                        counter++;
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
        private static void GetAllTrainersOnCourse(string title)
        {
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Trainers tr WHERE Email IN (SELECT TrainerEmail FROM TrainersCourse WHERE CourseTitle='{title}');";
                MySqlConnection connection = new MySqlConnection(DB_connection_string);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    connection.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    int counter = 0;
                    while (reader.Read())
                    {
                        Console.WriteLine($"Trainer: id={counter} {reader["FirstName"]}  {reader["LastName"]}  " +
                                      $"{reader["Email"]}  {reader["Phone"]}  {reader["Age"]} " +
                                      $"{reader["Gender"]}");
                        counter++;
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
            Console.WriteLine("\n");
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                string sql_query = $"SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE CourseTitle='{title}');";
                MySqlConnection connection = new MySqlConnection(DB_connection_string);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    connection.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: {reader["Title"]}  {reader["StartDate"]}  {reader["EndDate"]}");
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
            Console.WriteLine("\n");
            Console.Write("Enter Students Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("\n");
            if (email.Length > 0)
            {
                string sql_query = $"SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsStudents WHERE StudentEmail='{email}');";
                MySqlConnection connection = new MySqlConnection(DB_connection_string);
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    connection.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: {reader["Title"]}  {reader["StartDate"]}  {reader["EndDate"]}");
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
            Console.WriteLine("\n");
            string sql_query = $"SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse GROUP BY StudentEmail HAVING COUNT(*) > 1);";
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
            Console.WriteLine("\n");
            string sql_query = $"SELECT * FROM Students WHERE Email IN (SELECT StudentEmail FROM AssignmentsStudents " +
                $"WHERE AssignmentTitle IN (SELECT Title FROM Assignments WHERE WEEK(STR_TO_DATE(EndDate, '%d/%m/%y')) = WEEK(NOW())));";
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

