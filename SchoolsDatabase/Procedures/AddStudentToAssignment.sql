CREATE PROCEDURE [dbo].[AddStudentToAssignment]
@assignment VARCHAR(100), 
@studentemail VARCHAR(100)
AS
BEGIN
DECLARE @ass AS VARCHAR(100) = (SELECT Title FROM Assignment WHERE Title = @assignment),
		@student AS VARCHAR(300) = (SELECT Email FROM Students WHERE Email = @studentemail)
INSERT INTO StudentsCourse (StudentEmail, CourseTitle) VALUES (@student, @ass);
END
RETURN 0
