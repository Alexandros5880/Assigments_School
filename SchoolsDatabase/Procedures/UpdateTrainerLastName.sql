CREATE PROCEDURE UpdateTrainerLastName @lastname VARCHAR(50), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Trainers SET LastName=@lastname WHERE Email=@searchemail;
END
RETURN 0
