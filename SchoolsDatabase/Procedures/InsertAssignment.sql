CREATE PROCEDURE InsertAssignment @title VARCHAR(100), @startdate VARCHAR(30), @enddate VARCHAR(30), @description VARCHAR(500)
AS
BEGIN
INSERT INTO Assignments (Title, StartDate, EndDate, Description) VALUES (@title, @startdate, @enddate, @description);
END
RETURN 0
