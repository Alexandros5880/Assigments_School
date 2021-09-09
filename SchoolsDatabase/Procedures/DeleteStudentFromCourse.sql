CREATE PROCEDURE DeleteStudentFromCourse @coursetitle VARCHAR(100), @studentemail VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@student AS VARCHAR(300) = (SELECT Email FROM Students WHERE Email = @studentemail)
DELETE FROM StudentsCourse WHERE CourseTitle=@course AND StudentEmail=@student;
END
RETURN 0
