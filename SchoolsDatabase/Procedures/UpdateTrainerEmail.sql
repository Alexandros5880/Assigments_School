CREATE PROCEDURE UpdateTrainerEmail @email VARCHAR(33), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Trainers SET Email=@email WHERE Email=@searchemail;
END
RETURN 0
