/* Create Database and Select this Database */
CREATE DATABASE AssignmentsSchool;
USE AssignmentsSchool;

/* Create Tables */
CREATE TABLE Courses (
    Title NCHAR (255)   NOT NULL,
    StartDate  NCHAR (255) NULL,
    EndDate NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED (Title ASC)
);
CREATE TABLE Assignments ( /* Courses */
    Title NCHAR (255)   NOT NULL,
    StartDate  NCHAR (255) NULL,
    EndDate NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED (Title ASC)
);
CREATE TABLE Trainers ( /* Courses */
    FirstName NCHAR (255)   NULL,
    LastName  NCHAR (255) NULL,
    Age  INT NULL,
    Gender  NCHAR (255) NULL,
    StartDate  NCHAR (255) NULL,
    Email  NCHAR (255) NOT NULL UNIQUE,
    Phone  NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED (Email ASC)
);
CREATE TABLE Students ( /* Assignments, Courses */
    FirstName NCHAR (255)   NULL,
    LastName  NCHAR (255) NULL,
    Age  INT NULL,
    Gender  NCHAR (255) NULL,
    StartDate  NCHAR (255) NULL,
    Email  NCHAR (255) NOT NULL UNIQUE,
    Phone  NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED (Email ASC)
);
CREATE TABLE StudentsCourse (
    CourseTitle NCHAR (255) NOT NULL,
    StudentEmail NCHAR (255) NOT NULL,
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title),
    FOREIGN KEY (StudentEmail) REFERENCES Students(Email)
);
CREATE TABLE TrainersCourse (
    CourseTitle NCHAR (255) NOT NULL,
    TrainerEmail NCHAR (255) NOT NULL,
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title),
    FOREIGN KEY (TrainerEmail) REFERENCES Trainers(Email)
);
CREATE TABLE AssignmentsCourse (
    AssignmentTitle NCHAR (255) NULL,
    CourseTitle NCHAR (255) NULL,
    FOREIGN KEY (AssignmentTitle) REFERENCES Assignments (Title),
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
);
CREATE TABLE AssignmentsStudents (
    AssignmentTitle NCHAR (255) NULL,
    StudentEmail NCHAR (255) NOT NULL,
    FOREIGN KEY (AssignmentTitle) REFERENCES Assignments (Title),
    FOREIGN KEY (StudentEmail) REFERENCES Students(Email)
);


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

INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_1', '27/07/2021', '35/07/2021');
INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_2', '27/07/2021', '35/07/2021');
INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_3', '27/07/2021', '35/07/2021');
INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_4', '27/07/2021', '35/07/2021');
INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_5', '27/07/2021', '35/07/2021');

INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_1', '27/06/2021', '28/06/2021');
INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_2', '27/06/2021', '28/06/2021');
INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_3', '27/06/2021', '28/06/2021');
INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_4', '27/06/2021', '28/06/2021');
INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_5', '27/06/2021', '27/06/2021');



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


/* Request Queries */
/* Get All Students */
SELECT * FROM Students;
/* Get All Trainers */
SELECT * FROM Trainers;
/* Get All From Assignments */
SELECT * FROM Assignments;
/* Get All From Courses */
SELECT * FROM Courses;
/* Get All Students Of Specific Course */
SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse WHERE CourseTitle='Course_Test_1');
/* Get All Trainers Of Specific Course */
SELECT * FROM Trainers tr WHERE Email IN (SELECT TrainerEmail FROM TrainersCourse WHERE CourseTitle='Course_Test_1');
/* Get All Assignments Of Specific Course */
SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE CourseTitle='Course_Test_1');
/* Get All Assignments Of Specific Student */
SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsStudents WHERE StudentEmail='alexandrosplatanios151@gmail.com');
/* Get All Students Tha Belong To More That One Course */
SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse GROUP BY StudentEmail HAVING COUNT(*) > 1);
/* Get All Students Who Need To Submit Assignment On The Same Week */
SELECT * FROM Students WHERE Email IN (SELECT StudentEmail FROM AssignmentsStudents WHERE AssignmentTitle
                    IN (SELECT Title FROM Assignments WHERE WEEK(STR_TO_DATE(EndDate, '%d/%m/%y')) = WEEK(NOW())));


/* DROP EVERITHING */
DROP DATABASE AssignmentsSchool;