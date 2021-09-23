CREATE PROCEDURE [dbo].[GetStudentsEmailById]
	@id int = 0
AS
BEGIN
SELECT TOP 1 Email FROM Students WHERE Id = @id;
END
RETURN 0