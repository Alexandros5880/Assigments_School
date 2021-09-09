CREATE TABLE AssignmentsCourse (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    AssignmentTitle NCHAR (255) NULL,
    CourseTitle NCHAR (255) NULL,
    FOREIGN KEY (AssignmentTitle) REFERENCES Assignments (Title)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);