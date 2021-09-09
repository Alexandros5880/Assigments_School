CREATE PROCEDURE [dbo].[GetAllAssignmentsOfCourseById]
	@id int = 0
AS
BEGIN
SELECT * FROM Assignments WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE CourseTitle 
IN (SELECT TOP 1 Title FROM Courses WHERE Id = @id));
END
RETURN 0
