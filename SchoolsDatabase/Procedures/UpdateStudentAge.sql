CREATE PROCEDURE UpdateStudentAge @age VARCHAR(11), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Students SET Age=@age WHERE Email=@searchemail;
END
RETURN 0
