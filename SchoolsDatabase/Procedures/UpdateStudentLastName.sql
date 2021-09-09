CREATE PROCEDURE UpdateStudentLastName @lastname VARCHAR(50), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Students SET LastName=@lastname WHERE Email=@searchemail;
END
RETURN 0
