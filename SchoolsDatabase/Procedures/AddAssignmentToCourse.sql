CREATE PROCEDURE [AddAssignmentToCourse] @coursetitle VARCHAR(100), @assignmenttitle VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@assignment AS VARCHAR(100) = (SELECT Title FROM Assignments WHERE Title = @assignmenttitle)
INSERT INTO AssignmentsCourse (AssignmentTitle, CourseTitle) VALUES (@assignment,@course);
END
RETURN 0
