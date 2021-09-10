CREATE PROCEDURE [dbo].[GetTrainerById]
	@id int = 0
AS
BEGIN
SELECT TOP 1 * FROM Trainers WHERE Id = @id;
END
RETURN 0
