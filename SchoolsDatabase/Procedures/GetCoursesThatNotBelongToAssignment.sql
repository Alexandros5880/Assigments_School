CREATE PROCEDURE [dbo].[GetCoursesThatNotBelongToAssignment]
	@title VARCHAR(100)
	AS
BEGIN
SELECT * FROM Courses WHERE Title NOT IN (SELECT CourseTitle FROM AssignmentsCourse WHERE AssignmentTitle=@title);
END
RETURN 0
