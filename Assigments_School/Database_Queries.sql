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
    CourseTitle NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED (Title ASC),
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
);
CREATE TABLE Trainers ( /* Courses */
    FirstName NCHAR (255)   NULL,
    LastName  NCHAR (255) NULL,
    Age  INT NULL,
    Gender  NCHAR (255) NULL,
    StartDate  NCHAR (255) NULL,
    Email  NCHAR (255) NOT NULL UNIQUE,
    Phone  NCHAR (255) NULL,
    CourseTitle NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED (Email ASC),
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
);
CREATE TABLE Students ( /* Assignments, Courses */
    FirstName NCHAR (255)   NULL,
    LastName  NCHAR (255) NULL,
    Age  INT NULL,
    Gender  NCHAR (255) NULL,
    StartDate  NCHAR (255) NULL,
    Email  NCHAR (255) NOT NULL UNIQUE,
    Phone  NCHAR (255) NULL,
    AssignmentTitle NCHAR (255) NULL,
    CourseTitle NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED (Email ASC),
    FOREIGN KEY (AssignmentTitle) REFERENCES Assignments (Title),
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
);

/* Insert Test Records */
INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_1', '27/07/2021', '35/07/2021');
INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_2', '27/07/2021', '35/07/2021');
INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_3', '27/07/2021', '35/07/2021');
INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_4', '27/07/2021', '35/07/2021');
INSERT INTO Courses (Title, StartDate, EndDate) VALUES ('Course_Test_5', '27/07/2021', '35/07/2021');

INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_1', '27/07/2021', '35/07/2021');
INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_2', '27/07/2021', '35/07/2021');
INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_3', '27/07/2021', '35/07/2021');
INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_4', '27/07/2021', '35/07/2021');
INSERT INTO Assignments (Title, StartDate, EndDate) VALUES ('Assignment_Test_5', '27/07/2021', '35/07/2021');

INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_1', 'Platanios_Trainer_1', '29', 'm', '29/07/2021',
        'alexandrosplatanios151@gmail.com', '6949277783');
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_2', 'Platanios_Trainer_2', '29', 'm', '29/07/2021',
        'alexandrosplatanios152@gmail.com', '6949277783');
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_3', 'Platanios_Trainer_3', '29', 'm', '29/07/2021',
        'alexandrosplatanios153@gmail.com', '6949277783');
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_4', 'Platanios_Trainer_4', '29', 'm', '29/07/2021',
        'alexandrosplatanios154@gmail.com', '6949277783');
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Trainer_5', 'Platanios_Trainer_5', '29', 'm', '29/07/2021',
        'alexandrosplatanios155@gmail.com', '6949277783');

INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_1', 'Platanios_Student_1', '29', 'm', '29/07/2021',
        'alexandrosplatanios151@gmail.com', '6949277783');
INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_2', 'Platanios_Student_2', '29', 'm', '29/07/2021',
        'alexandrosplatanios152@gmail.com', '6949277783');
INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_3', 'Platanios_Student_3', '29', 'm', '29/07/2021',
        'alexandrosplatanios153@gmail.com', '6949277783');
INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_4', 'Platanios_Student_4', '29', 'm', '29/07/2021',
        'alexandrosplatanios154@gmail.com', '6949277783');
INSERT INTO Students (FirstName, LastName, Age, Gender, StartDate, Email, Phone)
VALUES ('Alexandros_Student_5', 'Platanios_Student_5', '29', 'm', '29/07/2021',
        'alexandrosplatanios155@gmail.com', '6949277783');

/* Update Records And Relate Trainers AND Students to Courses AND Assignments */
UPDATE Assignments SET CourseTitle='Course_Test_1' Where Title='Assignment_Test_1';
UPDATE Assignments SET CourseTitle='Course_Test_2' Where Title='Assignment_Test_2';
UPDATE Assignments SET CourseTitle='Course_Test_3' Where Title='Assignment_Test_3';
UPDATE Assignments SET CourseTitle='Course_Test_4' Where Title='Assignment_Test_4';
UPDATE Assignments SET CourseTitle='Course_Test_5' Where Title='Assignment_Test_5';

UPDATE Trainers SET CourseTitle='Course_Test_1' Where Email='alexandrosplatanios151@gmail.com';
UPDATE Trainers SET CourseTitle='Course_Test_2' Where Email='alexandrosplatanios152@gmail.com';
UPDATE Trainers SET CourseTitle='Course_Test_3' Where Email='alexandrosplatanios153@gmail.com';
UPDATE Trainers SET CourseTitle='Course_Test_4' Where Email='alexandrosplatanios154@gmail.com';
UPDATE Trainers SET CourseTitle='Course_Test_5' Where Email='alexandrosplatanios155@gmail.com';

UPDATE Students SET CourseTitle='Course_Test_1' Where Email='alexandrosplatanios151@gmail.com';
UPDATE Students SET CourseTitle='Course_Test_2' Where Email='alexandrosplatanios152@gmail.com';
UPDATE Students SET CourseTitle='Course_Test_3' Where Email='alexandrosplatanios153@gmail.com';
UPDATE Students SET CourseTitle='Course_Test_4' Where Email='alexandrosplatanios154@gmail.com';
UPDATE Students SET CourseTitle='Course_Test_5' Where Email='alexandrosplatanios155@gmail.com';

UPDATE Students SET AssignmentTitle='Assignment_Test_1' Where Email='alexandrosplatanios151@gmail.com';
UPDATE Students SET AssignmentTitle='Assignment_Test_2' Where Email='alexandrosplatanios152@gmail.com';
UPDATE Students SET AssignmentTitle='Assignment_Test_3' Where Email='alexandrosplatanios153@gmail.com';
UPDATE Students SET AssignmentTitle='Assignment_Test_4' Where Email='alexandrosplatanios154@gmail.com';
UPDATE Students SET AssignmentTitle='Assignment_Test_5' Where Email='alexandrosplatanios155@gmail.com';



/* Request Queries */

/* Get All Students */
SELECT * FROM Students;
/* Get All From Assignments */
SELECT * FROM Assignments;
/* Get All From Courses */
SELECT * FROM Courses;
/* Get All Students Of Specific Course */
SELECT * FROM Students stu WHERE (SELECT 1 FROM Courses CU WHERE stu.CourseTitle=cu.Title AND Title='Course_Test_3');
/* Get All Trainers Of Specific Course */
SELECT * FROM Trainers tr WHERE (SELECT 1 FROM Courses CU WHERE tr.CourseTitle=cu.Title AND Title='Course_Test_5');
/* Get All Assignments Of Specific Course */
SELECT * FROM Assignments ass WHERE (SELECT 1 FROM Courses CU WHERE ass.CourseTitle=cu.Title AND Title='Course_Test_1');
/* Get All Assignments Of Specific Student */
SELECT * FROM Assignments ass WHERE (SELECT 1 FROM Students st WHERE ass.Title=st.AssignmentTitle AND FirstName='Alexandros_Student_3');
/* Get All Students Tha Belong To More That One Course */
SELECT * FROM Students GROUP BY CourseTitle HAVING COUNT(*) > 1;


/* DROP EVERITHING */
DROP DATABASE AssignmentsSchool;