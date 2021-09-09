CREATE PROCEDURE UpdateTrainerAge @age VARCHAR(11), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Trainers SET Age=@age WHERE Email=@searchemail;
END
RETURN 0
