CREATE PROCEDURE InsertCourse @title VARCHAR(100), @startdate VARCHAR(30), @enddate VARCHAR(30), @description VARCHAR(500)
AS
BEGIN
INSERT INTO Courses (Title, StartDate, EndDate, Description) VALUES (@title, @startdate, @enddate, @description);
END
RETURN 0
