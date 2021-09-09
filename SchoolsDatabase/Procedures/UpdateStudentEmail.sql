CREATE PROCEDURE UpdateStudentEmail @email VARCHAR(33), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Students SET Email=@email WHERE Email=@searchemail;
END
RETURN 0
