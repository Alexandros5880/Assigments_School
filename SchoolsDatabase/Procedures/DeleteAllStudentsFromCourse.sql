CREATE PROCEDURE [dbo].[DeleteAllStudentsFromCourse]
	@title VARCHAR(100)
AS
BEGIN
	DELETE FROM StudentsCourses WHERE CourseTitle = @title
END
RETURN 0
