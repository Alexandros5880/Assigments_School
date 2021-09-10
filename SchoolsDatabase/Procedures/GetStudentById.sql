CREATE PROCEDURE [dbo].[GetStudentById]
	@id int = 0
AS
BEGIN
SELECT TOP 1 * FROM Students WHERE Id = @id;
END
RETURN 0
