/* Create Database and Select this Database */
CREATE DATABASE AssignmentsSchool;
GO
USE AssignmentsSchool;
GO

/* Create Tables */
CREATE TABLE Courses (
    Title NCHAR (255)   NOT NULL,
    StartDate  NCHAR (255) NULL,
    EndDate NCHAR (255) NULL,
    Description VARCHAR(500) NULL,
    PRIMARY KEY CLUSTERED (Title ASC)
);
GO
CREATE TABLE Assignments (
    Title NCHAR (255)   NOT NULL,
    StartDate  NCHAR (255) NULL,
    EndDate NCHAR (255) NULL,
    Description VARCHAR(500) NULL,
    PRIMARY KEY CLUSTERED (Title ASC)
);
GO
CREATE TABLE Trainers (
    FirstName NCHAR (255)   NULL,
    LastName  NCHAR (255) NULL,
    Age  INT NULL,
    Gender  NCHAR (255) NULL,
    StartDate  NCHAR (255) NULL,
    Email  NCHAR (255) NOT NULL UNIQUE,
    Phone  NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED (Email ASC)
);
GO
CREATE TABLE Students (
    FirstName NCHAR (255)   NULL,
    LastName  NCHAR (255) NULL,
    Age  INT NULL,
    Gender  NCHAR (255) NULL,
    StartDate  NCHAR (255) NULL,
    Email  NCHAR (255) NOT NULL UNIQUE,
    Phone  NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED (Email ASC)
);
GO
CREATE TABLE StudentsCourse (
    CourseTitle NCHAR (255) NOT NULL,
    StudentEmail NCHAR (255) NOT NULL,
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (StudentEmail) REFERENCES Students(Email) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);
GO
CREATE TABLE TrainersCourse (
    CourseTitle NCHAR (255) NOT NULL,
    TrainerEmail NCHAR (255) NOT NULL,
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (TrainerEmail) REFERENCES Trainers(Email)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
GO
CREATE TABLE AssignmentsCourse (
    AssignmentTitle NCHAR (255) NULL,
    CourseTitle NCHAR (255) NULL,
    FOREIGN KEY (AssignmentTitle) REFERENCES Assignments (Title)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
GO
CREATE TABLE AssignmentsStudents (
    AssignmentTitle NCHAR (255) NULL,
    StudentEmail NCHAR (255) NOT NULL,
    FOREIGN KEY (AssignmentTitle) REFERENCES Assignments (Title)
        ON DELETE CASCADE 
        ON UPDATE CASCADE,
    FOREIGN KEY (StudentEmail) REFERENCES Students(Email) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);
GO






/* Request Queries */
/* Get All Students */
GO
CREATE PROCEDURE GetAllStudents
AS
BEGIN
SELECT * FROM Students;
END
GO

/* Get All Trainers */
GO
CREATE PROCEDURE GetAllTrainers
AS
BEGIN
SELECT * FROM Trainers;
END
GO

/* Get All From Assignments */
GO
CREATE PROCEDURE GetAllAssignments
AS
BEGIN
SELECT * FROM Assignments;
END
GO

/* Get All From Courses */
GO
CREATE PROCEDURE GetAllCourses
AS
BEGIN
SELECT * FROM Courses;
END
GO

/* Get All Students Of Specific Course */
GO
CREATE PROCEDURE GetAllStudentsOfCourses @title VARCHAR(100)
AS
BEGIN
SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse WHERE CourseTitle=@title);
END
GO

/* Get All Trainers Of Specific Course */
GO
CREATE PROCEDURE GetAllTrainersOfCourses @title VARCHAR(100)
AS
BEGIN
SELECT * FROM Trainers tr WHERE Email IN (SELECT TrainerEmail FROM TrainersCourse WHERE CourseTitle=@title);
END
GO

/* Get All Assignments Of Specific Course */
GO
CREATE PROCEDURE GetAllAssignmentsOfCourses @title VARCHAR(100)
AS
BEGIN
SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE CourseTitle=@title);
END
GO

/* Get All Assignments Of Specific Student */
GO
CREATE PROCEDURE GetAllAssignmentsOfStudent @email VARCHAR(300)
AS
BEGIN
SELECT * FROM Assignments WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsStudents WHERE StudentEmail=@email);
END
GO

/* Get All Students Tha Belong To More That One Course */
GO
CREATE PROCEDURE GetAllStudentsThatBelongMoreToOneCourse
AS
BEGIN
SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse GROUP BY StudentEmail HAVING COUNT(*) > 1);
END
GO

/* Get All Students Who Need To Submit Assignment On The Same Week */
GO
CREATE PROCEDURE GetAllStudentsSubmitsAssOnSameWeek
AS
BEGIN
DECLARE @numGivenWeekDate AS VARCHAR(100)=(SELECT DATEPART(week, (SELECT CONVERT(DATE, (SELECT CAST( GETDATE() AS Date)), 103)))),
		@numNowWeekDate AS VARCHAR(100)=(SELECT DATEPART(week, (SELECT CAST( GETDATE() AS Date ))));
SELECT * FROM Students WHERE Email IN (SELECT StudentEmail FROM AssignmentsStudents WHERE AssignmentTitle IN 
                                        (SELECT Title FROM Assignments WHERE @numGivenWeekDate = @numGivenWeekDate ));
END
GO

/* Select All Assignments Per Course And Per Student */
GO
CREATE PROCEDURE GetAllAssignmentsOfOneStudent @coursetitle VARCHAR(100), @studentemail VARCHAR(300)
AS
BEGIN
SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE CourseTitle=@coursetitle)
                                AND Title IN (SELECT AssignmentTitle FROM AssignmentsStudents WHERE StudentEmail=@studentemail);
END
GO

/* Get All Students Who Need To Submit Assignment On The Same Week As The Date */
GO
CREATE PROCEDURE GetAllStudentsSubmitsAssOnSameWeekAsDate @date VARCHAR(30)
AS
BEGIN
DECLARE @week AS INT=(SELECT DATEPART(week, (SELECT CONVERT(DATE, @date, 103))));
SELECT * FROM Students WHERE Email IN
                             (SELECT StudentEmail FROM AssignmentsStudents
                             WHERE AssignmentTitle IN
                                   (SELECT Title FROM Assignments
                                   WHERE (SELECT DATEPART(week, (SELECT CONVERT(DATE, EndDate, 103)))) = @week));
END
GO






/* Edit Course */
/* Insert Course */
GO
CREATE PROCEDURE InsertCourse @title VARCHAR(100), @startdate VARCHAR(30), @enddate VARCHAR(30), @description VARCHAR(500)
AS
BEGIN
INSERT INTO Courses (Title, StartDate, EndDate, Description) VALUES (@title, @startdate, @enddate, @description);
END
GO
/* Edit Main Imfo */
GO
CREATE PROCEDURE UpdateCourse @title VARCHAR(100), @startdate VARCHAR(30), @enddate VARCHAR(30), @description VARCHAR(500), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Courses SET Title=@title, StartDate=@startdate, EndDate=@enddate, Description=@description WHERE Title=@searchtitle;
END
GO
/* Update Title */
GO
CREATE PROCEDURE UpdateCourseTitle @title VARCHAR(100), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Courses SET Title=@title WHERE Title=@searchtitle;
END
GO
/* Update Date */
GO
CREATE PROCEDURE UpdateCourseEndDate @enddate VARCHAR(30), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Courses SET EndDate=@enddate WHERE Title=@searchtitle;
END
GO
/* Update Description */
GO
CREATE PROCEDURE UpdateCourseEndDescription @description VARCHAR(500), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Courses SET Description=@description WHERE Title=@searchtitle;
END
GO
/* ADD Student To Course */
GO
CREATE PROCEDURE AddStudentToCourse @coursetitle VARCHAR(100), @studentemail VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@student AS VARCHAR(300) = (SELECT Email FROM Students WHERE Email = @studentemail)
INSERT INTO StudentsCourse (StudentEmail, CourseTitle) VALUES (@student, @course);
END
GO
/* Delete Student From Course */
GO
CREATE PROCEDURE DeleteStudentFromCourse @coursetitle VARCHAR(100), @studentemail VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@student AS VARCHAR(300) = (SELECT Email FROM Students WHERE Email = @studentemail)
DELETE FROM StudentsCourse WHERE CourseTitle=@course AND StudentEmail=@student;
END
GO
/* ADD Trainers To Course */
GO
CREATE PROCEDURE AddTrainerToCourse @coursetitle VARCHAR(100), @traineremail VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@trainer AS VARCHAR(300) = (SELECT Email FROM Trainers WHERE Email = @traineremail)
INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) VALUES (@trainer,@course);
END
GO
/* REMOVE Trainers From Course */
GO
CREATE PROCEDURE DeleteTrainerFromCourse @coursetitle VARCHAR(100), @traineremail VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@trainer AS VARCHAR(300) = (SELECT Email FROM Trainers WHERE Email = @traineremail)
DELETE FROM TrainersCourse WHERE CourseTitle=@course AND TrainerEmail=@trainer;
END
GO
/* Add Assignments To Course */
GO
CREATE PROCEDURE AddAssignmentToCourse @coursetitle VARCHAR(100), @assignmenttitle VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@assignment AS VARCHAR(100) = (SELECT Title FROM Assignments WHERE Title = @assignmenttitle)
INSERT INTO AssignmentsCourse (AssignmentTitle, CourseTitle) VALUES (@assignment,@course);
END
GO
/* REMOVE Assignments From Course */
GO
CREATE PROCEDURE DeleteAssignmentFromCourse @coursetitle VARCHAR(200), @assignmenttitle VARCHAR(200)
AS
BEGIN
DELETE FROM AssignmentsCourse WHERE CourseTitle=@coursetitle AND AssignmentTitle=@assignmenttitle;
END
GO
/* DELETE THIS COURSE  */
GO
CREATE PROCEDURE DeleteCourse @coursetitle VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle);
DELETE FROM AssignmentsCourse WHERE CourseTitle=@course;
DELETE FROM StudentsCourse WHERE CourseTitle=@course;
DELETE FROM TrainersCourse WHERE CourseTitle=@course;
DELETE FROM Courses WHERE Title=@course;
END
GO



/* Edit Assignments */
/* Insert Assignment */
GO
CREATE PROCEDURE InsertAssignment @title VARCHAR(100), @startdate VARCHAR(30), @enddate VARCHAR(30), @description VARCHAR(500)
AS
BEGIN
INSERT INTO Assignments (Title, StartDate, EndDate, Description) VALUES (@title, @startdate, @enddate, @description);
END
GO
/* Edit Main Imfo */
GO
CREATE PROCEDURE UpdateAssignment @title VARCHAR(100), @startdate VARCHAR(30), @enddate VARCHAR(30), @description VARCHAR(500), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Assignments SET Title=@title, StartDate=@startdate, EndDate=@enddate, Description=@description WHERE Title=@searchtitle;
END
GO

/* ADD Student To Assignment */
GO
CREATE PROCEDURE InsertStudentToAssignment @studentemail VARCHAR(100),  @assignmenttitle VARCHAR(100)
AS
BEGIN
INSERT INTO AssignmentsStudents (StudentEmail, AssignmentTitle) VALUES (@studentemail, @assignmenttitle);
END
GO
/* Delete Student From Assignment */
GO
CREATE PROCEDURE DeleteStudentFromAssignment @studentemail VARCHAR(100),  @assignmenttitle VARCHAR(100)
AS
BEGIN
DELETE FROM AssignmentsStudents WHERE AssignmentTitle=@assignmenttitle AND StudentEmail=@studentemail;
END
GO
/* Delete Assignment */
GO
CREATE PROCEDURE DeleteAssignment @assignmenttitle VARCHAR(100)
AS
BEGIN
DELETE FROM AssignmentsCourse WHERE AssignmentTitle=@assignmenttitle;
DELETE FROM AssignmentsStudents WHERE AssignmentTitle=@assignmenttitle;
DELETE FROM Assignments WHERE Title=@assignmenttitle;
END
GO


/* Student */
/* Insert Student */
GO
CREATE PROCEDURE InsertStudent @firstname VARCHAR(50), @lastname VARCHAR(50), @age VARCHAR(15), 
								@gender VARCHAR(10), @startdate VARCHAR(30), @email VARCHAR(300), @phone VARCHAR(15)
AS
BEGIN
INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone) 
VALUES (@firstname, @lastname, @age, @gender, @startdate, @email, @phone);
END
GO
/* Edit Student */
GO
CREATE PROCEDURE UpdateStudent @firstname VARCHAR(50), @lastname VARCHAR(50), @age INT, 
								@gender VARCHAR(10), @email VARCHAR(300), @phone VARCHAR(15), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Students SET FirstName=@firstname, LastName=@lastname, Age=@age, Gender=@gender, Email=@email, Phone=@phone WHERE Email=@searchemail;
END
GO
/* Delete Student */
GO
CREATE PROCEDURE DeleteStudent @email VARCHAR(300)
AS
BEGIN
DELETE FROM Students WHERE Email=@email;END
GO

/* Trainer */
/* Insert Trainer */
CREATE PROCEDURE InsertTrainer @firstname VARCHAR(50), @lastname VARCHAR(50), @age VARCHAR(15), 
								@gender VARCHAR(10), @startdate VARCHAR(30), @email VARCHAR(300), @phone VARCHAR(15)
AS
BEGIN
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone) VALUES (@firstname, @lastname, @age, @gender, @startdate, @email, @phone);
END
GO
/* Edit Trainer */
GO
CREATE PROCEDURE UpdateTrainer @firstname VARCHAR(50), @lastname VARCHAR(50), @age INT, 
								@gender VARCHAR(10), @email VARCHAR(300), @phone VARCHAR(15), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Trainers SET FirstName=@firstname, LastName=@lastname, Age=@age, Gender=@gender, Email=@email, Phone=@phone WHERE Email=@searchemail;
END
GO
/* Delete Trainer */
GO
CREATE PROCEDURE DeleteTrainer @email VARCHAR(300)
AS
BEGIN
DELETE FROM Trainers WHERE Email=@email;END
GO














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








/* DROP EVERITHING */
DROP DATABASE AssignmentsSchool;



