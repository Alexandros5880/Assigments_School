CREATE PROCEDURE AddStudentToCourse 
@coursetitle VARCHAR(100), 
@studentemail VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@student AS VARCHAR(300) = (SELECT Email FROM Students WHERE Email = @studentemail)
INSERT INTO StudentsCourse (StudentEmail, CourseTitle) VALUES (@student, @course);
END
RETURN 0
