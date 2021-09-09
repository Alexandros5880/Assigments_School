/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



                                   /* Insert Test Records */
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_1', 'Platanios_Trainer_1', '29', 'Male', '29/07/2021',
        'alexandrosplatanios151@gmail.com', '6949277783');
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_2', 'Platanios_Trainer_2', '29', 'Male', '29/07/2021',
        'alexandrosplatanios152@gmail.com', '6949277783');
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_3', 'Platanios_Trainer_3', '29', 'Male', '29/07/2021',
        'alexandrosplatanios153@gmail.com', '6949277783');
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_4', 'Platanios_Trainer_4', '29', 'Male', '29/07/2021',
        'alexandrosplatanios154@gmail.com', '6949277783');
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_5', 'Platanios_Trainer_5', '29', 'Male', '29/07/2021',
        'alexandrosplatanios155@gmail.com', '6949277783');

INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_1', 'Platanios_Student_1', '29', 'Male', '29/07/2021',
        'alexandrosplatanios151@gmail.com', '6949277783');
INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_2', 'Platanios_Student_2', '29', 'Male', '29/07/2021',
        'alexandrosplatanios152@gmail.com', '6949277783');
INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_3', 'Platanios_Student_3', '29', 'Male', '29/07/2021',
        'alexandrosplatanios153@gmail.com', '6949277783');
INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_4', 'Platanios_Student_4', '29', 'Male', '29/07/2021',
        'alexandrosplatanios154@gmail.com', '6949277783');
INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_5', 'Platanios_Student_5', '29', 'Male', '29/07/2021',
        'alexandrosplatanios155@gmail.com', '6949277783');

INSERT INTO Courses (Title, StartDate, EndDate, Description) VALUES ('Course_Test_1', '27/07/2021', '35/07/2021', 'Test Description');
INSERT INTO Courses (Title, StartDate, EndDate, Description) VALUES ('Course_Test_2', '27/07/2021', '35/07/2021', 'Test Description');
INSERT INTO Courses (Title, StartDate, EndDate, Description) VALUES ('Course_Test_3', '27/07/2021', '35/07/2021', 'Test Description');
INSERT INTO Courses (Title, StartDate, EndDate, Description) VALUES ('Course_Test_4', '27/07/2021', '35/07/2021', 'Test Description');
INSERT INTO Courses (Title, StartDate, EndDate, Description) VALUES ('Course_Test_5', '27/07/2021', '35/07/2021', 'Test Description');

INSERT INTO Assignments (Title, StartDate, EndDate, Description) VALUES ('Assignment_Test_1', '27/06/2021', '28/06/2021', 'Test Description');
INSERT INTO Assignments (Title, StartDate, EndDate, Description) VALUES ('Assignment_Test_2', '27/06/2021', '28/06/2021', 'Test Description');
INSERT INTO Assignments (Title, StartDate, EndDate, Description) VALUES ('Assignment_Test_3', '27/06/2021', '28/06/2021', 'Test Description');
INSERT INTO Assignments (Title, StartDate, EndDate, Description) VALUES ('Assignment_Test_4', '27/06/2021', '28/06/2021', 'Test Description');
INSERT INTO Assignments (Title, StartDate, EndDate, Description) VALUES ('Assignment_Test_5', '27/06/2021', '27/06/2021', 'Test Description');



INSERT INTO StudentsCourse (StudentEmail, CourseTitle) VALUES ('alexandrosplatanios151@gmail.com','Course_Test_1');
INSERT INTO StudentsCourse (StudentEmail, CourseTitle) VALUES ('alexandrosplatanios152@gmail.com','Course_Test_2');
INSERT INTO StudentsCourse (StudentEmail, CourseTitle) VALUES ('alexandrosplatanios153@gmail.com','Course_Test_3');
INSERT INTO StudentsCourse (StudentEmail, CourseTitle) VALUES ('alexandrosplatanios153@gmail.com','Course_Test_4');

INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) VALUES ('alexandrosplatanios151@gmail.com','Course_Test_1');
INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) VALUES ('alexandrosplatanios152@gmail.com','Course_Test_1');
INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) VALUES ('alexandrosplatanios153@gmail.com','Course_Test_1');

INSERT INTO AssignmentsCourse (AssignmentTitle, CourseTitle) VALUES ('Assignment_Test_1','Course_Test_1');
INSERT INTO AssignmentsCourse (AssignmentTitle, CourseTitle) VALUES ('Assignment_Test_3','Course_Test_1');
INSERT INTO AssignmentsCourse (AssignmentTitle, CourseTitle) VALUES ('Assignment_Test_4','Course_Test_1');
INSERT INTO AssignmentsCourse (AssignmentTitle, CourseTitle) VALUES ('Assignment_Test_5','Course_Test_1');

INSERT INTO AssignmentsStudents (AssignmentTitle, StudentEmail) VALUES ('Assignment_Test_1','alexandrosplatanios151@gmail.com');
INSERT INTO AssignmentsStudents (AssignmentTitle, StudentEmail) VALUES ('Assignment_Test_2','alexandrosplatanios153@gmail.com');
INSERT INTO AssignmentsStudents (AssignmentTitle, StudentEmail) VALUES ('Assignment_Test_3','alexandrosplatanios153@gmail.com');
INSERT INTO AssignmentsStudents (AssignmentTitle, StudentEmail) VALUES ('Assignment_Test_4','alexandrosplatanios154@gmail.com');