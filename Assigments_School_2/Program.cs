using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_School_2
{
    class Program
    {

        static SchoolsDBEntities school = new SchoolsDBEntities();

        static void Main(string[] args)
        {
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
                            GetAllStudentsWhoNeedToSubmitAssignmentsOnTheSameWeekAsThisDate();
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
                Console.WriteLine("\n");
            }
        }






        ///////////////////////////////////////////  IMPORTING FUNCTIONS /////////////////////////////////////////////////////////
        // Import Course
        private static string AddCourse()
        {
            try
            {
                int id = -1;
                string email = "";
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
                    // Insert Course
                    school.InsertCourse(title, startdate, enddate, description);
                    school.SaveChanges();
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
                            switch (tr_choice)
                            {
                                case "new":
                                    email = AddTrainer();
                                    // Add Trainer Tou Course
                                    school.AddTrainerToCourse(title, email);
                                    school.SaveChanges();
                                    break;
                                case "ex":
                                    Console.WriteLine("Select Trainer By Id(3): ");
                                    GetAllTrainers();
                                    try { id = int.Parse(Console.ReadLine()); } catch(Exception) { }
                                    if(id != -1)
                                    {
                                        // Get Trainer By Id
                                        ObjectResult<GetTrainerById_Result> result = school.GetTrainerById(id);
                                        email = result.ToString();
                                        // Add Trainer To DataBase
                                        school.AddTrainerToCourse(title, email);
                                        school.SaveChanges();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a valid id!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter A Valid Choice!");
                                    break;
                            }
                        }
                    }
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
                            switch (st_choice)
                            {
                                case "new":
                                    email = AddStudent();
                                    // Add Student To DataBase
                                    school.AddStudentToCourse(title, email);
                                    school.SaveChanges();
                                    break;
                                case "ex":
                                    Console.WriteLine("Select Student By Id(3): ");
                                    GetAllStudents();
                                    try { id = int.Parse(Console.ReadLine()); } catch (Exception) { }
                                    if (id != -1)
                                    {
                                        id = int.Parse(Console.ReadLine());
                                        ObjectResult<GetStudentById_Result> result = school.GetStudentById(id);
                                        email = result.ToString();
                                        // Add Student To DataBase
                                        school.AddStudentToCourse(title, email);
                                        school.SaveChanges();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a valid id!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter A Valid Choice!");
                                    break;
                            }
                        }
                    }
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
        private static string AddAssignment()
        {
            try
            {
                int id = -1;
                string email = "";
                string course_title = "";
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
                    // Add Assignment 
                    school.InsertAssignment(title, startdate, enddate, description);
                    school.SaveChanges();
                    // Add Assignment to Course
                    Console.WriteLine("\n");
                    Console.WriteLine("Select Course By Id(3): ");
                    GetAllCourses();
                    try { id = int.Parse(Console.ReadLine()); } catch(Exception) { }
                    if(id != -1)
                    {
                        ObjectResult<GetCourseById_Result> result = school.GetCourseById(id);
                        course_title = result.ToString();
                        school.AddAssignmentToCourse(course_title, title);
                    }
                    if(course_title != "")
                    {
                        do
                        {
                            // Get From Course All Students And Select Students To Add Them To Assignment
                            Console.WriteLine("\n");
                            Console.WriteLine("Select Student By Id(3): ");
                            // Get All Students Of This Course
                            GetAllStudentsOnCourseByTitle(course_title);
                            // Create Assignment To Student Record
                            try { id = int.Parse(Console.ReadLine()); } catch (Exception) { }
                            if (id != -1)
                            {
                                ObjectResult<GetStudentById_Result> result = school.GetStudentById(id);
                                email = result.ToString();
                            }
                            if (email.Length > 0)
                            {
                                // Add To AssignmentsStudents DataBase
                                school.AddStudentToAssignment(title, email);
                                school.SaveChanges();
                            }
                            Console.WriteLine("Add More Students: yes(y) - no(n)");
                            string choice = Console.ReadLine();
                            if (choice.Equals("no")) { break; }
                        } while (true);
                    }
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
        // Import Students
        private static string AddStudent()
        {
            try
            {
                Console.WriteLine("\n");
                string firstname = "", lastname = "", age="", gender = "", startdate = "", email = "", phone = "";
                Console.Write("FirstName: ");
                firstname = Console.ReadLine();
                Console.Write("LastName: ");
                lastname = Console.ReadLine();
                Console.Write("Age: ");
                age = Console.ReadLine();
                Console.Write("Gender (Male)?(Female): ");
                gender = Console.ReadLine();
                Console.Write("Email: ");
                email = Console.ReadLine();
                Console.Write("Phone: ");
                phone = Console.ReadLine();
                startdate = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));
                if (firstname.Length > 0 && lastname.Length > 0 && int.Parse(age) > 0 && int.Parse(age) < 133 &&
                    email.Length > 0 && phone.Length > 0 && gender.Length > 0)
                {
                    // Insert Student
                    school.InsertStudent(firstname, lastname, age, gender, startdate, email, phone);
                    school.SaveChanges();
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
                string firstname = "", lastname = "", gender = "", age="", startdate = "", email = "", phone = "";
                Console.Write("FirstName: ");
                firstname = Console.ReadLine();
                Console.Write("LastName: ");
                lastname = Console.ReadLine();
                Console.Write("Age: ");
                age = Console.ReadLine();
                Console.Write("Gender (Male)?(Female): ");
                gender = Console.ReadLine();
                Console.Write("Email: ");
                email = Console.ReadLine();
                Console.Write("Phone: ");
                phone = Console.ReadLine();
                startdate = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));
                if (firstname.Length > 0 && lastname.Length > 0 && int.Parse(age) > 0 && int.Parse(age) < 133 &&
                    email.Length > 0 && phone.Length > 0 && gender.Length > 0)
                {
                    // Insert Trainer
                    school.InsertTrainer(firstname, lastname, age, gender, startdate, email, phone);
                    school.SaveChanges();
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
            Console.WriteLine("Select Course By Id:\n");
            GetAllCourses();
            Console.Write("\nEnter Id: ");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid id!");
            }
            if (id != -1)
            {
                string course_title = "";
                string conntact_email = "";
                string title = "";
                string choice = "";
                // region "Get Course By Id
                ObjectResult<GetCourseById_Result> result_1 = school.GetCourseById(id);
                course_title = result_1.ToString();
                Console.WriteLine("\n");
                while (true)
                {
                    Console.Write("Quit(stop) ? Edit MainImfo(main) ? ADD/REMOVE Students(st) ? ADD/REMOVE Trainers(tr) ? " +
                        "ADD/REMOVE Assignments(ass) ? Delete this Course(del): ");
                    choice = Console.ReadLine();
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
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "t":
                                        Console.WriteLine("\n");
                                        Console.Write("Enter new Title: ");
                                        title = Console.ReadLine();
                                        if (title.Length > 0)
                                        {
                                            // Update Title
                                            school.UpdateCourseTitle(title, course_title);
                                            school.SaveChanges();
                                        }
                                        title = "";
                                        break;
                                    case "date":
                                        Console.WriteLine("\n");
                                        Console.Write($"Enter New EndDate Like ({DateTime.Today.ToString("dd/MM/yyy", CultureInfo.CreateSpecificCulture("es-ES"))}): ");
                                        string enddate = Console.ReadLine();
                                        if (enddate.Length > 0)
                                        {
                                            // Update EndDate
                                            school.UpdateCourseEndDate(enddate, course_title);
                                            school.SaveChanges();
                                        }
                                        break;
                                    case "d":
                                        Console.WriteLine("\n");
                                        Console.Write("Enter new Description: ");
                                        string description = Console.ReadLine();
                                        if (description.Length > 0)
                                        {
                                            // Update Description
                                            school.UpdateCourseEndDescription(description, course_title);
                                            school.SaveChanges();
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "st": // Edit Students
                                Console.WriteLine("\n");
                                Console.Write("Add(add) ? Remove(del): ");
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "add": // Add Student
                                        Console.WriteLine("\n");
                                        while (true)
                                        {
                                            Console.Write("Stop(stop) ? Add New Student(new) ? Add Existing Student(ex): ");
                                            choice = Console.ReadLine();
                                            if (choice.Equals("stop"))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                switch (choice)
                                                {
                                                    case "new": // New Student
                                                        conntact_email = AddStudent();
                                                        school.AddStudentToCourse(course_title, conntact_email);
                                                        school.SaveChanges();
                                                        break;
                                                    case "ex": // Existing Student
                                                        Console.WriteLine("Select Student By Id(3):\n");
                                                        GetAllStudents();
                                                        Console.WriteLine("\nEnter Id: ");
                                                        id = int.Parse(Console.ReadLine());
                                                        ObjectResult<GetStudentById_Result> result_3 = school.GetStudentById(id);
                                                        conntact_email = result_3.ToString();
                                                        school.AddStudentToCourse(course_title, conntact_email);
                                                        school.SaveChanges();
                                                        break;
                                                    default:
                                                        Console.WriteLine("Enter A Valid Choice!");
                                                        break;
                                                }
                                            }
                                        }
                                        conntact_email = "";
                                        break;
                                    case "del": // Delete Student
                                        Console.WriteLine("Select Student By Id(3):\n");
                                        GetAllStudentsOnCourseByTitle(course_title);
                                        Console.WriteLine("\nEnter Id: ");
                                        id = int.Parse(Console.ReadLine());
                                        ObjectResult<GetStudentById_Result> result_2 = school.GetStudentById(id);
                                        conntact_email = result_2.ToString();
                                        school.DeleteStudentFromCourse(course_title, conntact_email);
                                        school.SaveChanges();
                                        break;
                                    default:
                                        conntact_email = "";
                                        Console.WriteLine("Enter A Valid Choice!");
                                        break;
                                }
                                break;
                            case "tr": // Edit Trainers
                                Console.WriteLine("\n");
                                Console.Write("Add(add) ? Remove(del): ");
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "add": // Add Trainer
                                        Console.WriteLine("\n");
                                        while (true)
                                        {
                                            Console.Write("Stop(stop) ? Add New Trainer(new) ? Add Existing Trainer(ex): ");
                                            choice = Console.ReadLine();
                                            if (choice.Equals("stop"))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                switch (choice)
                                                {
                                                    case "new": // New Trainer
                                                        conntact_email = AddTrainer();
                                                        #region "Add Trainer To DB"
                                                        school.AddTrainerToCourse(course_title, conntact_email);
                                                        school.SaveChanges();
                                                        break;
                                                    case "ex": // Existing Trainer
                                                        Console.WriteLine("Select Trainer By Id(3):\n");
                                                        GetAllTrainers();
                                                        Console.Write("\nEnter Id: ");
                                                        id = int.Parse(Console.ReadLine());
                                                        ObjectResult<GetTrainerById_Result> result_2 = school.GetTrainerById(id);
                                                        conntact_email = result_2.ToString();
                                                        school.AddTrainerToCourse(course_title, conntact_email);
                                                        school.SaveChanges();
                                                        break;
                                                    default:
                                                        Console.WriteLine("Enter A Valid Choice!");
                                                        break;
                                                }
                                            }
                                        }
                                        conntact_email = "";
                                        break;
                                    case "del": // Delete Trainer
                                        Console.WriteLine("Select Trainer By Id(3):\n");
                                        GetAllTrainersOnCourse(course_title);
                                        Console.Write("\nExter Id: ");
                                        id = int.Parse(Console.ReadLine());
                                        ObjectResult<GetTrainerById_Result> result_2 = school.GetTrainerById(id);
                                        conntact_email = result_2.ToString();
                                        school.DeleteTrainerFromCourse(course_title, conntact_email);
                                        school.SaveChanges();
                                        break;
                                    default:
                                        Console.WriteLine("Enter A Valid Choice!");
                                        break;
                                }
                                break;
                            case "ass": // Edit Assignments
                                Console.WriteLine("\n");
                                Console.Write("Add(add) ? Remove(del): ");
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "add": // Add Assignments
                                        Console.WriteLine("\n");
                                        while (true)
                                        {
                                            Console.Write("Stop(stop) ? Add New Assignment(new) ? Add Existing Assignment(ex): ");
                                            choice = Console.ReadLine();
                                            if (choice.Equals("stop"))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                switch (choice)
                                                {
                                                    case "new":
                                                        title = AddAssignment();
                                                        school.AddAssignmentToCourse(course_title, title);
                                                        school.SaveChanges();
                                                        break;
                                                    case "ex":
                                                        Console.WriteLine("Select Assignment By Id(3):\n");
                                                        GetAllAssignments();
                                                        Console.Write("\nEnter Id: ");
                                                        id = int.Parse(Console.ReadLine());
                                                        ObjectResult<GetAssignmentById_Result> result_2 = school.GetAssignmentById(id);
                                                        title = result_2.ToString();
                                                        school.AddAssignmentToCourse(course_title, title);
                                                        school.SaveChanges();
                                                        break;
                                                    default:
                                                        Console.WriteLine("Enter A Valid Choice!");
                                                        break;
                                                }
                                            }
                                        }
                                        title = "";
                                        break;
                                    case "del":
                                        Console.WriteLine("Select Assignment By Id(3): ");
                                        GetAllAssignmentsPerCourse(course_title);
                                        id = int.Parse(Console.ReadLine());
                                        ObjectResult<GetAssignmentById_Result> result_2 = school.GetAssignmentById(id);
                                        title = result_2.ToString();
                                        school.DeleteAssignmentFromCourse(course_title, title);
                                        school.SaveChanges();
                                        break;
                                    default:
                                        Console.WriteLine("Enter A Valid Choice!");
                                        break;
                                }
                                break;
                            case "del": // Delete This Course
                                school.DeleteCourse(title);
                                school.SaveChanges();
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
                Console.WriteLine("Enter a valid ID!");
            }
        }
        // Edit Assignment
        private static void EditAssignment()
        {
            Console.WriteLine("Select Assignment By Id:\n");
            GetAllAssignments();
            Console.Write("\nEnter Id: ");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid ID!.");
            }
            if (id != -1)
            {
                string assignment_title = "";
                string conntact_email = "";
                string title = "";
                string choice = "";
                ObjectResult<GetAssignmentById_Result> result_1 = school.GetAssignmentById(id);
                assignment_title = result_1.ToString();
                while (true)
                {
                    Console.Write("Quit(stop) ? Edit MainImfo(main) ? ADD/REMOVE Students(st) ? Delete This Assignment(del): ");
                    choice = Console.ReadLine();
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
                                    choice = Console.ReadLine();
                                    if (choice.Length > 0)
                                    {
                                        if (choice.Equals("stop"))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            switch (choice)
                                            {
                                                case "title": // Edit Title
                                                    Console.Write("Enter New Title: ");
                                                    title = Console.ReadLine();
                                                    if (title.Length > 0)
                                                    {
                                                        school.UpdateAssignmentsTitle(title, assignment_title);
                                                        school.SaveChanges();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Enter A Valid Title!");
                                                    }
                                                    break;
                                                case "date":
                                                    Console.Write($"Enter EndDate Like({DateTime.Today.ToString("dd/MM/yyy", CultureInfo.CreateSpecificCulture("es-ES"))}): ");
                                                    string enddate = Console.ReadLine();
                                                    if (enddate.Length > 0)
                                                    {
                                                        school.UpdateAssignmentsDate(enddate, assignment_title);
                                                        school.SaveChanges();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Enter A Valid Date!");
                                                    }
                                                    break;
                                                case "de":
                                                    Console.Write("Enter New Description: ");
                                                    string description = Console.ReadLine();
                                                    if (description.Length > 0)
                                                    {
                                                        school.UpdateAssignmentsDescription(description, assignment_title);
                                                        school.SaveChanges();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Enter A Valid Description!");
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("No Valid Choice!");
                                                    break;
                                            }
                                        }
                                    }
                                }
                                break;
                            case "st": // Edit Student
                                Console.WriteLine("\n");
                                Console.Write("Add(add) ? Remove(del): ");
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "add": // Add Student To Assignment
                                        Console.WriteLine("\n");
                                        while (true)
                                        {
                                            Console.Write("Stop(stop) ? Add New Student(new) ? Add Existing Student(ex): ");
                                            choice = Console.ReadLine();
                                            if (choice.Equals("stop"))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                switch (choice)
                                                {
                                                    case "new": // New Student
                                                        conntact_email = AddStudent();
                                                        school.AddStudentToAssignment(assignment_title, conntact_email);
                                                        school.SaveChanges();
                                                        break;
                                                    case "ex": // Existing Student
                                                        Console.WriteLine("Select Student By Id(3):\n");
                                                        GetAllStudents();
                                                        Console.WriteLine("\nEnter Id: ");
                                                        id = int.Parse(Console.ReadLine());
                                                        ObjectResult<GetStudentById_Result> result_2 = school.GetStudentById(id);
                                                        conntact_email = result_2.ToString();
                                                        school.AddStudentToAssignment(assignment_title, conntact_email);
                                                        school.SaveChanges();
                                                        break;
                                                    default:
                                                        Console.WriteLine("Enter A Valid Choice!");
                                                        break;
                                                }
                                            }
                                        }
                                        break;
                                    case "del": // Delete Student From Assignment
                                        // Get Parents Course Title;
                                        title = GetCourseTitleByAssignmentTitle(assignment_title);
                                        // Select ALL Students On This Assignment
                                        Console.WriteLine("Select Student By Id(3): ");
                                        GetAllStudentsOnAssignment(title);
                                        id = int.Parse(Console.ReadLine());
                                        ObjectResult<GetStudentById_Result> result_2 = school.GetStudentById(id);
                                        conntact_email = result_2.ToString();
                                        school.DeleteStudentFromAssignment(conntact_email, assignment_title);
                                        school.SaveChanges();
                                        break;
                                    default:
                                        Console.WriteLine("Enter A Valid Choice!");
                                        break;
                                }
                                break;
                            case "del": // Delete Assignment
                                school.DeleteAssignment(assignment_title);
                                school.SaveChanges();
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
            Console.WriteLine("Select Trainer By Id:\n");
            GetAllTrainers();
            Console.Write("\nEnter Id: ");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine()) - 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid ID!");
            }
            string trainer_email = "";
            #region "Get Trainer By Id"
            _query = $"EXEC GetTrainerById {id};";
            try
            {
                _command = new SqlCommand(_query, _connection);
                _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();
                students.Clear();
                while (reader.Read())
                {
                    trainer_email = reader["Email"].ToString().Trim();
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
                _connection.Close();
            }
            #endregion
            if (id != -1)
            {
                string choice = "";
                Console.WriteLine("\n");
                while (true)
                {
                    Console.Write("Quit(stop) ? Edit MainImfo(main) ? Delete This Trainer(del): ");
                    choice = Console.ReadLine();
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
                                choice = Console.ReadLine();
                                if (choice.Length > 0)
                                {
                                    switch (choice)
                                    {
                                        case "fn": // Edit FistName
                                            Console.WriteLine("\n");
                                            Console.Write("Enter New FirstName: ");
                                            string firstname = Console.ReadLine();
                                            if (firstname.Length > 0)
                                            {
                                                #region "Update FirstName"
                                                _query = $"EXEC UpdateTrainerFirstName '{firstname}', '{trainer_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update LastName"
                                                _query = $"EXEC UpdateTrainerLastName '{lastname}', '{trainer_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update Age"
                                                _query = $"EXEC UpdateTrainerAge '{age}', '{trainer_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update Gender"
                                                _query = $"EXEC UpdateTrainerGender '{gender}', '{trainer_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update Email"
                                                _query = $"EXEC UpdateTrainerEmail '{email}', '{trainer_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update Phone"
                                                _query = $"EXEC UpdateTrainerPhone '{phone}', '{trainer_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                #region "Delete Trainer"
                                _query = $"EXEC DeleteTrainer '{trainer_email}';";
                                try
                                {
                                    _command = new SqlCommand(_query, _connection);
                                    _connection.Open();
                                    var reader = _command.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    _connection.Close();
                                }
                                #endregion
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
            Console.WriteLine("Select Student By Id:\n");
            GetAllStudents();
            Console.Write("\nEnter Id: ");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine()) - 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid ID!");
            }
            if (id != -1)
            {
                string student_email = "";
                #region "Get Student By Id"
                _query = $"EXEC GetStudentById {id};";
                try
                {
                    _command = new SqlCommand(_query, _connection);
                    _connection.Open();
                    SqlDataReader reader = _command.ExecuteReader();
                    students.Clear();
                    while (reader.Read())
                    {
                        student_email = reader["Email"].ToString().Trim();
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
                    _connection.Close();
                }
                #endregion
                Console.WriteLine("\n");
                while (true)
                {
                    Console.Write("Quit(stop) ? Edit MainImfo(main) ? Delete This Student(del): ");
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
                                                #region "Update FirstName"
                                                _query = $"EXEC UpdateStudentFirstName '{firstname}', '{student_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update LastName"
                                                _query = $"EXEC UpdateStudentLastName '{lastname}', '{student_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update Age"
                                                _query = $"EXEC UpdateStudentAge '{age}', '{student_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update Gender"
                                                _query = $"EXEC UpdateStudentGender '{gender}', '{student_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update Email"
                                                _query = $"EXEC UpdateStudentEmail '{email}', '{student_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                                #region "Update Phone"
                                                _query = $"EXEC UpdateStudentPhone '{phone}', '{student_email}';";
                                                try
                                                {
                                                    _command = new SqlCommand(_query, _connection);
                                                    _connection.Open();
                                                    var reader = _command.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Exception: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    _connection.Close();
                                                }
                                                #endregion
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
                                #region "Delete Student"
                                _query = $"EXEC DeleteStudent '{student_email}';";
                                try
                                {
                                    _command = new SqlCommand(_query, _connection);
                                    _connection.Open();
                                    var reader = _command.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                                finally
                                {
                                    _connection.Close();
                                }
                                #endregion
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
            _query = "EXEC GetAllStudents;";
            try
            {
                _command = new SqlCommand(_query, _connection);
                _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();
                students.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: id={reader["Id"].ToString().Trim()} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                      $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                      $"{reader["Gender"].ToString().Trim()}");
                    students.Add(reader["Email"].ToString().Trim());
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
                _connection.Close();
            }
        }
        // Get All Trainers From DB
        private static void GetAllTrainers()
        {
            _query = "EXEC GetAllTrainers;";
            try
            {
                _command = new SqlCommand(_query, _connection);
                _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();
                trainers.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Trainer: id={reader["Id"].ToString().Trim()} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                      $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                      $"{reader["Gender"].ToString().Trim()}");
                    trainers.Add(reader["Email"].ToString());
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
                _connection.Close();
            }
        }
        // Get All Assignments FromDB
        private static void GetAllAssignments()
        {
            _query = "EXEC GetAllAssignments;";
            try
            {
                _command = new SqlCommand(_query, _connection);
                _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Assignment: id={reader["Id"].ToString().Trim()} {reader["Title"].ToString().Trim()}  " +
                        $"{reader["StartDate"].ToString().Trim()} {reader["EndDate"].ToString().Trim()}");
                    assignments.Add(reader["Title"].ToString().Trim());
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
                _connection.Close();
            }
        }
        // Get All Courses FromDB
        private static void GetAllCourses()
        {
            _query = "EXEC GetAllCourses;";
            try
            {
                _command = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                courses.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Course: id={reader["Id"].ToString().Trim()} Title: {reader["Title"].ToString().Trim()} " +
                        $"{reader["StartDate"].ToString().Trim()} {reader["EndDate"].ToString().Trim()}");
                    courses.Add(reader["Title"].ToString().Trim());
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
                _connection.Close();
            }
        }
        // Get All Students Per Course
        private static void GetAllStudentsOnCourse()
        {
            Console.Write("Select Course By Id: ");
            Console.WriteLine("\n");
            GetAllCourses();
            Console.Write("\nEnter Id: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                _query = $"EXEC GetAllStudentsOfCourseById '{id}';";
                _command = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                students.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: Id={reader["Id"].ToString().Trim()} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                    $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                    $"{reader["Gender"].ToString().Trim()}");
                    students.Add(reader["Email"].ToString().Trim());
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
                _connection.Close();
            }
        }
        // Get All Students Per Course
        private static void GetAllStudentsOnCourseByTitle(string title)
        {
            _query = $"EXEC GetAllStudentsOfCourses '{title}';";
            try
            {
                _command = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                students.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Student: Id={reader["Id"].ToString().Trim()} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
                                  $"{reader["Email"].ToString().Trim()}  {reader["Phone"].ToString().Trim()}  {reader["Age"].ToString().Trim()} " +
                                  $"{reader["Gender"].ToString().Trim()}");
                    students.Add(reader["Email"].ToString().Trim());
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
                _connection.Close();
            }
        }
        // Get All Trainers Per Course
        private static void GetAllTrainersOnCourse()
        {
            Console.Write("Select Course By Id: ");
            Console.WriteLine("\n");
            GetAllCourses();
            Console.Write("\nEnter Id: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                _query = $"EXEC GetAllTrainersOfCourseById '{id}';";
                _command = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Trainer: id={reader["Id"].ToString().Trim()} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
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
                _connection.Close();
            }
        }
        // Get All Trainers Per Course
        private static void GetAllTrainersOnCourse(string title)
        {
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                _query = $"EXEC GetAllTrainersOfCourses '{title}';";
                try
                {
                    _command = new SqlCommand(_query, _connection);
                    _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Trainer: id={reader["Id"].ToString().Trim()} {reader["FirstName"].ToString().Trim()}  {reader["LastName"].ToString().Trim()}  " +
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
                    _connection.Close();
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
            Console.Write("Select Course By Id: ");
            Console.WriteLine("\n");
            GetAllAssignments();
            Console.Write("\nEnter Id: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                _query = $"EXEC GetAllAssignmentsOfCourseById {id};";
                _command = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                assignments.Clear();
                while (reader.Read())
                {
                    Console.WriteLine($"Assignment: id={reader["Id"].ToString().Trim()} {reader["Title"].ToString().Trim()}  " +
                        $"{reader["StartDate"].ToString().Trim()}  {reader["EndDate"].ToString().Trim()}");
                    assignments.Add(reader["Title"].ToString().Trim());
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
                _connection.Close();
            }
        }
        // Get All Assignments Per Course
        private static void GetAllAssignmentsPerCourse(string title)
        {
            Console.WriteLine("\n");
            if (title.Length > 0)
            {
                _query = $"EXEC GetAllAssignmentsOfCourses '{title}';";
                try
                {
                    _command = new SqlCommand(_query, _connection);
                    _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();
                    assignments.Clear();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: id={reader["Id"].ToString().Trim()} {reader["Title"].ToString().Trim()}  " +
                            $"{reader["StartDate"].ToString().Trim()}  {reader["EndDate"].ToString().Trim()}");
                        assignments.Add(reader["Title"].ToString().Trim());
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
                    _connection.Close();
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
                _query = $"EXEC GetAllStudentsOfAssignment '{title}';";
                try
                {
                    _command = new SqlCommand(_query, _connection);
                    _connection.Open();
                    SqlDataReader reader = _command.ExecuteReader();
                    assignments.Clear();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Assignment: id={reader["Id"].ToString().Trim()} {reader["Title"].ToString().Trim()}  " +
                            $"{reader["StartDate"].ToString().Trim()}  {reader["EndDate"].ToString().Trim()}");
                        assignments.Add(reader["Title"].ToString());
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
                    _connection.Close();
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
            if (title.Length > 0)
            {
                // Get Title Of This Course
                _query = $"EXEC GetCourseTitleByAssignmentTitle '{title}';";
                try
                {
                    _command = new SqlCommand(_query, _connection);
                    _connection.Open();
                    SqlDataReader reader = _command.ExecuteReader();
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
                    _connection.Close();
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
            Console.Write("Select Course By Id: ");
            Console.WriteLine("\n");
            GetAllAssignments();
            Console.Write("\nEnter Id: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                _query = $"EXEC GetAllAssignmentsOfStudentById '{id}';";
                _command = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
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
                _connection.Close();
            }
        }
        // Get All Students That Belong To More That One Course
        private static void GetAllStudentsThatBelongToMoreThatOneCourse()
        {
            Console.WriteLine("\n");
            _query = $"EXEC GetAllStudentsThatBelongMoreToOneCourse;";
            try
            {
                _command = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
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
                _connection.Close();
            }
        }
        // Get All Assignments Per Course And Student
        private static void GetAllAssignmentsPerCourseAndStudent()
        {
            try
            {
                Console.Write("Select Course By Id: ");
                Console.WriteLine("\n");
                GetAllCourses();
                Console.Write("\nEnter Id: ");
                int c_id = int.Parse(Console.ReadLine());
                Console.Write("Select Student By Id: ");
                Console.WriteLine("\n");
                GetAllStudents();
                Console.Write("\nEnter Id: ");
                int s_id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                _query = $"EXEC GetAllAssignmentsPerCourseAndStudentByIds {c_id}, {s_id};";
                _command = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
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
                _connection.Close();
            }
        }
        // Get All Students Who Need To Submit AssigNments On The Same Week
        private static void GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek()
        {
            Console.WriteLine("\n");
            _query = $"EXEC GetAllStudentsSubmitsAssOnSameWeek;";
            try
            {
                _command = new SqlCommand(_query, _connection);
                _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();
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
                _connection.Close();
            }
        }
        // Get All Students Who Need To Submeet An Assignment On The Same Week As The Date
        private static void GetAllStudentsWhoNeedToSubmitAssignmentsOnTheSameWeekAsThisDate()
        {
            Console.WriteLine("\n");
            Console.Write($"Enter A Date Like({DateTime.Today.ToString("dd/MM/yyy", CultureInfo.CreateSpecificCulture("es-ES"))}): ");
            string date = Console.ReadLine();
            Console.WriteLine("\n");
            if (date.Length > 0)
            {
                _query = $"EXEC GetAllStudentsSubmitsAssOnSameWeekAsDate '{date}'";
                try
                {
                    _command = new SqlCommand(_query, _connection);
                    _connection.Open();
                    SqlDataReader reader = _command.ExecuteReader();
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
                    _connection.Close();
                }
            }
        }










    }
}
