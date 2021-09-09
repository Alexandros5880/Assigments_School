CREATE TABLE Students (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NCHAR (255)   NULL,
    LastName  NCHAR (255) NULL,
    Age  INT NULL,
    Gender  NCHAR (255) NULL,
    StartDate  NCHAR (255) NULL,
    Email  NCHAR (255) NOT NULL UNIQUE,
    Phone  NCHAR (255) NULL
);