CREATE PROCEDURE UpdateTrainerGender @gender VARCHAR(33), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Trainers SET Gender=@gender WHERE Email=@searchemail;
END
RETURN 0
