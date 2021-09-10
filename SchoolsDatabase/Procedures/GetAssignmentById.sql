CREATE PROCEDURE [dbo].[GetAssignmentById]
	@id int = 0
AS
BEGIN
SELECT * FROM Assignments WHERE Id = @id;
END
RETURN 0
