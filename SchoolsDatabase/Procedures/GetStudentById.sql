CREATE PROCEDURE [dbo].[GetStudentById]
	@id int = 0
AS
BEGIN
	SELECT * FROM Students WHERE Id = @id
END
RETURN 0
