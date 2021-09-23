CREATE PROCEDURE [dbo].[GetTrainersEmailById]
	@id int = 0
AS
BEGIN
	SELECT TOP 1 Email FROM Trainers WHERE Id = @id;
END
RETURN 0
