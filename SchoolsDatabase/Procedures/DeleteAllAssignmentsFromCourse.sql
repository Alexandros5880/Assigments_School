CREATE PROCEDURE [dbo].[DeleteAllAssignmentsFromCourse]
	@title VARCHAR(100)
AS
BEGIN
	DELETE FROM AssignmentsCourses WHERE CourseTitle = @title
END
RETURN 0
