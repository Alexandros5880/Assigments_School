using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject
{
    public class SchoolTerminalHelper
    {
        internal SchoolsDBEntities school = new SchoolsDBEntities();

        ///////////////////////////////////////////  IMPORTING FUNCTIONS /////////////////////////////////////////////////////////
        // Import Course
        public string AddCourse()
        {
            try
            {
                int id = -1;
                string email = "";
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
                    this.school.InsertCourse(title, startdate, enddate, description);
                    this.school.SaveChanges();
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
                                    this.school.AddTrainerToCourse(title, email);
                                    this.school.SaveChanges();
                                    break;
                                case "ex":
                                    Console.WriteLine("Select Trainer By Id(3):\n");
                                    GetAllTrainers();
                                    Console.Write("\nEnter Id: ");
                                    try 
                                    { 
                                        id = int.Parse(Console.ReadLine()); 
                                    } 
                                    catch (Exception ex) 
                                    {
                                        Console.WriteLine($"[ERROR]: {ex.Message}");
                                    }
                                    if (id != -1)
                                    {
                                        // Get Trainer By Id
                                        email = this.school.GetTrainersEmailById(id).FirstOrDefault();
                                        // Add Trainer To DataBase
                                        try
                                        {
                                            this.school.AddTrainerToCourse(title, email);
                                            this.school.SaveChanges();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"[Error]: {ex.Message}");
                                        }
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
                                    this.school.AddStudentToCourse(title, email);
                                    this.school.SaveChanges();
                                    break;
                                case "ex":
                                    Console.WriteLine("Select Student By Id(3):\n");
                                    GetAllStudents();
                                    Console.Write("\nEnter Id: ");
                                    try
                                    {
                                        id = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception ex) 
                                    {
                                        Console.WriteLine($"[Error]: {ex.Message}");
                                    }
                                    if (id != -1)
                                    {
                                        email = this.school.GetStudentsEmailById(id).FirstOrDefault();
                                        // Add Student To DataBase
                                        this.school.AddStudentToCourse(title, email);
                                        this.school.SaveChanges();
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
        public string AddAssignment()
        {
            try
            {
                int id = -1;
                string email = "";
                string course_title = "";
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
                    this.school.InsertAssignment(title, startdate, enddate, description);
                    this.school.SaveChanges();
                    // Add Assignment to Course
                    Console.WriteLine("\n");
                    Console.WriteLine("Select Course By Id(3):\n");
                    GetAllCourses();
                    Console.Write("\nEnter Id: ");
                    try 
                    {
                        id = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Error]: {ex.Message}");
                    }
                    if (id != -1)
                    {
                        course_title = this.school.GetCourseById(id).FirstOrDefault().Title;
                        this.school.AddAssignmentToCourse(course_title, title);
                    }
                    if (course_title != "")
                    {
                        do
                        {
                            // Get From Course All Students And Select Students To Add Them To Assignment
                            Console.WriteLine("\n");
                            Console.WriteLine("Select Student By Id(3): ");
                            // Get All Students Of This Course
                            GetAllStudentsOnCourseByTitle(course_title);
                            // Create Assignment To Student Record
                            Console.Write("\nEnter Id: ");
                            try
                            {
                                id = int.Parse(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[Error]: {ex.Message}");
                            }
                            if (id != -1)
                            {
                                email = this.school.GetStudentsEmailById(id).FirstOrDefault();
                            }
                            if (email.Length > 0)
                            {
                                // Add To AssignmentsStudents DataBase
                                this.school.AddStudentToAssignment(title, email);
                                this.school.SaveChanges();
                            }
                            Console.WriteLine("Add More Students: yes(y) - no(n)");
                            string choice = Console.ReadLine();
                            if (choice.Equals("no") || choice.Equals("n")) { break; }
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
        // Import Trainers
        public string AddTrainer()
        {
            try
            {
                string firstname = "", lastname = "", gender = "", age = "", startdate = "", email = "", phone = "";
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
                    this.school.InsertTrainer(firstname, lastname, age, gender, startdate, email, phone);
                    this.school.SaveChanges();
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
        // Import Students
        public string AddStudent()
        {
            try
            {
                string firstname = "", lastname = "", age = "", gender = "", startdate = "", email = "", phone = "";
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
                    this.school.InsertStudent(firstname, lastname, age, gender, startdate, email, phone);
                    this.school.SaveChanges();
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

        //TODO 1).   Edit Functions.
        //////////////////////////////////////////  EDITING RECORDS FUNCTIONS /////////////////////////////////////////////////////////
        // Edit Course
        public void EditCourse()
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
                course_title = this.school.GetCourseById(id).FirstOrDefault().Title;
                Console.WriteLine("\n");
                while (true)
                {
                    Console.Write("Quit(stop) ? Edit MainImfo(main) ? ADD/REMOVE Students(st) ? ADD/REMOVE Trainers(tr) ? " +
                        "ADD/REMOVE Assignments(ass) ? Delete this Course(del): ");
                    choice = Console.ReadLine();
                    if (choice.Equals("stop"))
                    {
                        Console.WriteLine("");
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
                                            this.school.UpdateCourseTitle(title, course_title);
                                            this.school.SaveChanges();
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
                                            this.school.UpdateCourseEndDate(enddate, course_title);
                                            this.school.SaveChanges();
                                        }
                                        break;
                                    case "d":
                                        Console.WriteLine("\n");
                                        Console.Write("Enter new Description: ");
                                        string description = Console.ReadLine();
                                        if (description.Length > 0)
                                        {
                                            // Update Description
                                            this.school.UpdateCourseEndDescription(description, course_title);
                                            this.school.SaveChanges();
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
                                                        this.school.AddStudentToCourse(course_title, conntact_email);
                                                        this.school.SaveChanges();
                                                        break;
                                                    case "ex": // Existing Student
                                                        Console.WriteLine("Select Student By Id(3):\n");
                                                        GetAllStudents();
                                                        Console.Write("\nEnter Id: ");
                                                        id = int.Parse(Console.ReadLine());
                                                        conntact_email = this.school.GetStudentsEmailById(id).FirstOrDefault();
                                                        this.school.AddStudentToCourse(course_title, conntact_email);
                                                        this.school.SaveChanges();
                                                        Console.WriteLine("");
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
                                        Console.Write("\nEnter Id: ");
                                        id = int.Parse(Console.ReadLine());
                                        conntact_email = this.school.GetStudentsEmailById(id).FirstOrDefault();
                                        this.school.DeleteStudentFromCourse(course_title, conntact_email);
                                        this.school.SaveChanges();
                                        Console.WriteLine("");
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
                                                        this.school.AddTrainerToCourse(course_title, conntact_email);
                                                        this.school.SaveChanges();
                                                        break;
                                                    case "ex": // Existing Trainer
                                                        Console.WriteLine("Select Trainer By Id(3):\n");
                                                        GetAllTrainers();
                                                        Console.Write("\nEnter Id: ");
                                                        id = int.Parse(Console.ReadLine());
                                                        conntact_email = this.school.GetTrainersEmailById(id).FirstOrDefault();
                                                        this.school.AddTrainerToCourse(course_title, conntact_email);
                                                        this.school.SaveChanges();
                                                        Console.WriteLine("");
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
                                        conntact_email = this.school.GetTrainersEmailById(id).FirstOrDefault();
                                        this.school.DeleteTrainerFromCourse(course_title, conntact_email);
                                        this.school.SaveChanges();
                                        Console.WriteLine("");
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
                                                        this.school.AddAssignmentToCourse(course_title, title);
                                                        this.school.SaveChanges();
                                                        break;
                                                    case "ex":
                                                        Console.WriteLine("Select Assignment By Id(3):\n");
                                                        GetAllAssignments();
                                                        Console.Write("\nEnter Id: ");
                                                        id = int.Parse(Console.ReadLine());
                                                        title = this.school.GetAssignmentById(id).FirstOrDefault().Title;
                                                        this.school.AddAssignmentToCourse(course_title, title);
                                                        this.school.SaveChanges();
                                                        Console.WriteLine("");
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
                                        title = this.school.GetAssignmentById(id).FirstOrDefault().Title;
                                        this.school.DeleteAssignmentFromCourse(course_title, title);
                                        this.school.SaveChanges();
                                        Console.WriteLine("");
                                        break;
                                    default:
                                        Console.WriteLine("Enter A Valid Choice!");
                                        break;
                                }
                                break;
                            case "del": // Delete This Course
                                this.school.DeleteCourse(title);
                                this.school.SaveChanges();
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
        public void EditAssignment()
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
                ObjectResult<GetAssignmentById_Result> result_1 = this.school.GetAssignmentById(id);
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
                                                        this.school.UpdateAssignmentsTitle(title, assignment_title);
                                                        this.school.SaveChanges();
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
                                                        this.school.UpdateAssignmentsDate(enddate, assignment_title);
                                                        this.school.SaveChanges();
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
                                                        this.school.UpdateAssignmentsDescription(description, assignment_title);
                                                        this.school.SaveChanges();
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
                                                        this.school.AddStudentToAssignment(assignment_title, conntact_email);
                                                        this.school.SaveChanges();
                                                        break;
                                                    case "ex": // Existing Student
                                                        Console.WriteLine("Select Student By Id(3):\n");
                                                        GetAllStudents();
                                                        Console.WriteLine("\nEnter Id: ");
                                                        id = int.Parse(Console.ReadLine());
                                                        ObjectResult<GetStudentById_Result> result_3 = this.school.GetStudentById(id);
                                                        conntact_email = result_3.ToString();
                                                        this.school.AddStudentToAssignment(assignment_title, conntact_email);
                                                        this.school.SaveChanges();
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
                                        ObjectResult<GetStudentById_Result> result_2 = this.school.GetStudentById(id);
                                        conntact_email = result_2.ToString();
                                        this.school.DeleteStudentFromAssignment(conntact_email, assignment_title);
                                        this.school.SaveChanges();
                                        break;
                                    default:
                                        Console.WriteLine("Enter A Valid Choice!");
                                        break;
                                }
                                break;
                            case "del": // Delete Assignment
                                this.school.DeleteAssignment(assignment_title);
                                this.school.SaveChanges();
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
        public void EditTrainer()
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
            string trainer_email = this.school.GetTrainerById(id).ToString();
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
                                                this.school.UpdateTrainerFirstName(firstname, trainer_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateTrainerLastName(lastname, trainer_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateTrainerAge(age, trainer_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateTrainerGender(gender, trainer_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateTrainerEmail(email, trainer_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateTrainerPhone(phone, trainer_email);
                                                this.school.SaveChanges();
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
                                this.school.DeleteTrainer(trainer_email);
                                this.school.SaveChanges();
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
        public void EditStudent()
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
                string student_email = this.school.GetStudentById(id).ToString();
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
                                                this.school.UpdateStudentFirstName(firstname, student_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateStudentLastName(lastname, student_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateStudentAge(age, student_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateStudentGender(gender, student_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateStudentEmail(email, student_email);
                                                this.school.SaveChanges();
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
                                                this.school.UpdateStudentPhone(phone, student_email);
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
                                this.school.DeleteStudent(student_email);
                                this.school.SaveChanges();
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
        public void GetAllStudents()
        {
            foreach (var r in this.school.GetAllStudents())
            {
                Console.WriteLine($"Student: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
        // Get All Trainers From DB
        public void GetAllTrainers()
        {
            foreach (var r in this.school.GetAllTrainers())
            {
                Console.WriteLine($"Trainer: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
        // Get All Assignments FromDB
        public void GetAllAssignments()
        {
            foreach (var r in this.school.GetAllAssignments())
            {
                Console.WriteLine($"Assignment: id={r.Id.ToString().Trim()} {r.Title.ToString().Trim()} " +
                    $"{r.StartDate.ToString().Trim()} {r.EndDate.ToString().Trim()}");
            }
        }
        // Get All Courses FromDB
        public void GetAllCourses()
        {
            foreach (var r in this.school.GetAllCourses())
            {
                Console.WriteLine($"Course: id={r.Id.ToString().Trim()} {r.Title.ToString().Trim()} " +
                    $"{r.StartDate.ToString().Trim()} {r.EndDate.ToString().Trim()}");
            }
        }
        // Get All Students Per Course
        public void GetAllStudentsOnCourse()
        {
            Console.Write("Select Course By Id: ");
            Console.WriteLine("\n");
            GetAllCourses();
            Console.Write("\nEnter Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllStudentsOfCourseById(id))
            {
                Console.WriteLine($"Student: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
        // Get All Students Per Course
        public void GetAllStudentsOnCourseByTitle(string title)
        {
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllStudentsOfCourses(title))
            {
                Console.WriteLine($"Student: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
        // Get All Trainers Per Course
        public void GetAllTrainersOnCourse()
        {
            Console.Write("Select Course By Id: ");
            Console.WriteLine("\n");
            GetAllCourses();
            Console.Write("\nEnter Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllTrainersOfCourseById(id))
            {
                Console.WriteLine($"Trainer: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
        // Get All Trainers Per Course
        public void GetAllTrainersOnCourse(string title)
        {
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllTrainersOfCourses(title))
            {
                Console.WriteLine($"Trainer: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
        // Get All Assignments Per Course
        public void GetAllAssignmentsPerCourse()
        {
            Console.Write("Select Course By Id: ");
            Console.WriteLine("\n");
            GetAllCourses();
            Console.Write("\nEnter Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllAssignmentsOfCourseById(id))
            {
                Console.WriteLine($"Assignment: id={r.Id.ToString().Trim()} {r.Title.ToString().Trim()} " +
                    $"{r.StartDate.ToString().Trim()} {r.EndDate.ToString().Trim()}");
            }
        }
        // Get All Assignments Per Course
        public void GetAllAssignmentsPerCourse(string title)
        {
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllAssignmentsOfCourses(title))
            {
                Console.WriteLine($"Assignment: id={r.Id.ToString().Trim()} {r.Title.ToString().Trim()} " +
                    $"{r.StartDate.ToString().Trim()} {r.EndDate.ToString().Trim()}");
            }
        }
        // Get All Students On Assignment
        public void GetAllStudentsOnAssignment(string title)
        {
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllStudentsOfAssignment(title))
            {
                Console.WriteLine($"Student: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
        // Get The Parent Courses Title Of An Assignment
        public string GetCourseTitleByAssignmentTitle(string title)
        {
            return this.school.GetCourseTitleByAssignmentTitle(title).ToString();
        }
        // Get All Assignments Per Student
        public void GetAllAssignmentsPerStudent()
        {
            Console.Write("Select Student By Id: ");
            Console.WriteLine("\n");
            GetAllStudents();
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllAssignmentsOfStudentById(id))
            {
                Console.WriteLine($"Assignment: id={r.Id.ToString().Trim()} {r.Title.ToString().Trim()} " +
                    $"{r.StartDate.ToString().Trim()} {r.EndDate.ToString().Trim()}");
            }
        }
        // Get All Students That Belong To More That One Course
        public void GetAllStudentsThatBelongToMoreThatOneCourse()
        {
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllStudentsThatBelongMoreToOneCourse())
            {
                Console.WriteLine($"Student: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
        // Get All Assignments Per Course And Student
        public void GetAllAssignmentsPerCourseAndStudent()
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
            foreach (var r in this.school.GetAllAssignmentsPerCourseAndStudentByIds(c_id, s_id))
            {
                Console.WriteLine($"Assignment: id={r.Id.ToString().Trim()} {r.Title.ToString().Trim()} " +
                    $"{r.StartDate.ToString().Trim()} {r.EndDate.ToString().Trim()}");
            }

        }
        // Get All Students Who Need To Submit AssigNments On The Same Week
        public void GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek()
        {
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllStudentsSubmitsAssOnSameWeek())
            {
                Console.WriteLine($"Student: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
        // Get All Students Who Need To Submeet An Assignment On The Same Week As The Date
        public void GetAllStudentsWhoNeedToSubmitAssignmentsOnTheSameWeekAsThisDate()
        {
            Console.WriteLine("\n");
            Console.Write($"Enter A Date Like({DateTime.Today.ToString("dd/MM/yyy", CultureInfo.CreateSpecificCulture("es-ES"))}): ");
            string date = Console.ReadLine();
            Console.WriteLine("\n");
            foreach (var r in this.school.GetAllStudentsSubmitsAssOnSameWeekAsDate(date))
            {
                Console.WriteLine($"Student: id={r.Id.ToString().Trim()} {r.FirstName.ToString().Trim()}  {r.LastName.ToString().Trim()}  " +
                    $"{r.Email.ToString().Trim()}  {r.Phone.ToString().Trim()}  {r.Age.ToString().Trim()}  {r.Gender.ToString().Trim()}");
            }
        }
    }
}
