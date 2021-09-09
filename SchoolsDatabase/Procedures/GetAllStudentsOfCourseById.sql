CREATE PROCEDURE [dbo].[GetAllStudentsOfCourseById]
	@id int = 0
AS
BEGIN
SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse WHERE CourseTitle 
IN (SELECT TOP 1 Title FROM Courses WHERE Id = @id));
END
RETURN 0
