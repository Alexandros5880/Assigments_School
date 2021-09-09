CREATE TABLE Assignments (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    Title NCHAR (255) UNIQUE NOT NULL,
    StartDate  NCHAR (255) NULL,
    EndDate NCHAR (255) NULL,
    Description VARCHAR(500) NULL
);