CREATE PROCEDURE [dbo].[GetAssignmentByTitle]
	@title VARCHAR(100)
AS
BEGIN
SELECT * FROM Assignments WHERE Title = @title
END
RETURN 0
