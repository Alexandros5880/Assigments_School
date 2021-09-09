CREATE PROCEDURE UpdateTrainerPhone @phone VARCHAR(33), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Trainers SET Phone=@phone WHERE Email=@searchemail;
END
RETURN 0
