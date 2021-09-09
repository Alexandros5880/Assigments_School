CREATE TABLE StudentsCourse (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    CourseTitle NCHAR (255) NOT NULL,
    StudentEmail NCHAR (255) NOT NULL,
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (StudentEmail) REFERENCES Students(Email) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);