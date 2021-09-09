CREATE TABLE TrainersCourse (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    CourseTitle NCHAR (255) NOT NULL,
    TrainerEmail NCHAR (255) NOT NULL,
    FOREIGN KEY (CourseTitle) REFERENCES Courses(Title)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (TrainerEmail) REFERENCES Trainers(Email)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);