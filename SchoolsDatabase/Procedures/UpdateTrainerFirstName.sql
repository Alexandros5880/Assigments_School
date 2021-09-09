CREATE PROCEDURE UpdateTrainerFirstName @firstname VARCHAR(50), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Trainers SET FirstName=@firstname WHERE Email=@searchemail;
END
RETURN 0
