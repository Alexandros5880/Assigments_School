CREATE PROCEDURE [dbo].[GetCourseByTitle]
	@title VARCHAR(100)
AS
BEGIN
SELECT * FROM Courses WHERE Title = @title;
END
RETURN 0
