CREATE PROCEDURE [dbo].[GetCourseById]
	@id int = 0
AS
BEGIN
SELECT * FROM Courses WHERE Id = @id;
END
RETURN 0
