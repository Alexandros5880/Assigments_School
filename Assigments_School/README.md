##### Setup:
* Edit Program.cs
* On Class Program Set **db_server_name** and **db_name_**
* Run the **Database_Queries.sql_** file
* Run The Program.


##### SQL Procedures:
    -- Export Data
    EXEC GetAllStudents;
    EXEC GetAllTrainers;
    EXEC GetAllAssignments;
    EXEC GetAllCourses;
    EXEC GetAllStudentsOfCourses 'Course_Test_1';
    EXEC GetAllTrainersOfCourses 'Course_Test_1';
    EXEC GetAllAssignmentsOfCourses 'Course_Test_1';
    EXEC GetAllAssignmentsOfStudent 'alexandrosplatanios151@gmail.com';
    EXEC GetAllStudentsOfAssignment 'Assignment_Test_1';
    EXEC GetAllStudentsThatBelongMoreToOneCourse;
    EXEC GetCourseTitleByAssignmentTitle 'Assignment_Test_1';
    EXEC GetAllStudentsSubmitsAssOnSameWeek;
    EXEC GetAllAssignmentsPerCourseAndStudent 'Course_Test_1', 'alexandrosplatanios151@gmail.com';
    EXEC GetAllAssignmentsOfOneStudent 'Course_Test_1', 'alexandrosplatanios151@gmail.com';
    EXEC GetAllStudentsSubmitsAssOnSameWeekAsDate '28/06/2021';

    -- Courses
    EXEC InsertCourse 'Course_Test_1', '28/06/2021', '28/07/2021', 'Description';
    EXEC UpdateCourse 'Course_Test_1', '28/06/2021', '28/07/2021', 'Test Description New', 'Course_Test_1';
    EXEC UpdateCourseTitle 'Course_Test_1', 'Course_Test_1';
    EXEC UpdateCourseEndDate '30/6/2021', 'Course_Test_1';
    EXEC UpdateCourseEndDescription 'Test Description', 'Course_Test_1';
    EXEC AddStudentToCourse 'Course_Test_1', 'alexandrosplatanios152@gmail.com';
    EXEC DeleteStudentToCourse 'Course_Test_1', 'alexandrosplatanios152@gmail.com';
    EXEC AddTrainerToCourse 'Course_Test_1', 'alexandrosplatanios154@gmail.com';
    EXEC DeleteTrainerToCourse 'Course_Test_1', 'alexandrosplatanios154@gmail.com';
    EXEC AddAssignmentToCourse 'Course_Test_1', 'Assignment_Test_5';
    EXEC DeleteAssignmentFromCourse 'Course_Test_1', 'Assignment_Test_5';
    EXEC DeleteCourse 'Course_Test_1';

    -- Assignments
    EXEC InsertAssignment 'Assignment_Test_1', '28/08/2021', '28/09/2021', 'Test Description New';
    EXEC UpdateAssignment 'Assignment_Test_1', '28/08/2021', '28/09/2021', 'Test Description New', 'Assignment_Test_1';
    EXEC UpdateAssignmentsTitle 'Assignment_Test_1', 'Assignment_Test_1';
    EXEC UpdateAssignmentsDate '27/07/2021', 'Assignment_Test_1';
    EXEC UpdateAssignmentsDescription 'Test Description', 'Assignment_Test_1';
    EXEC InsertStudentToAssignment 'alexandrosplatanios152@gmail.com', 'Assignment_Test_1';
    EXEC DeleteStudentFromAssignment 'alexandrosplatanios152@gmail.com', 'Assignment_Test_1';
    EXEC DeleteAssignment 'Assignment_Test_1';

    -- Students
    EXEC InsertStudent 'Alexandros_Student_1', 'Platanios_Student_1', '30', 'Male', 'startdate', 'Alexpl_15@windowslive.com', '6949277783';
    EXEC UpdateStudent 'Alexandros_Student_1', 'Platanios_Student_1', '30', 'Male', 'Alexpl_15@windowslive.com', '6949277783', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateStudentFirstName 'Alexandros_Trainer_1', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateStudentLastName 'Alexandros_Platanios_1', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateStudentAge '30', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateStudentGender 'Male', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateStudentEmail 'Alexpl_15@windowslive.com', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateStudentPhone '6937317201', 'alexandrosplatanios151@gmail.com';
    EXEC DeleteStudent 'Alexpl_15@windowslive.com';

    -- Tariners
    EXEC InsertTrainer 'Alexandros_Trainer_1', 'Platanios_Trainer_1', '30', 'Male', 'startdate', 'Alexpl_15@windowslive.com', '6949277783';
    EXEC UpdateTrainer 'Alexandros_Trainer_1', 'Platanios_Trainer_1', '30', 'Male', 'Alexpl_15@windowslive.com', '6949277783', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateTrainerFirstName 'Alexandros_Trainer_1', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateTrainerLastName 'Platanios_Trainer_1', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateTrainerAge '30', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateTrainerGender 'Male', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateTrainerEmail 'Alexpl_15@windowslive.com', 'alexandrosplatanios151@gmail.com';
    EXEC UpdateTrainerPhone '6937317201', 'alexandrosplatanios151@gmail.com';
    EXEC DeleteTrainer 'alexandrosplatanios151@gmail.com';