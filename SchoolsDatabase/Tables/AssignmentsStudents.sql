CREATE TABLE AssignmentsStudents (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    AssignmentTitle NCHAR (255) NULL,
    StudentEmail NCHAR (255) NOT NULL,
    FOREIGN KEY (AssignmentTitle) REFERENCES Assignments (Title)
        ON DELETE CASCADE 
        ON UPDATE CASCADE,
    FOREIGN KEY (StudentEmail) REFERENCES Students(Email) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);