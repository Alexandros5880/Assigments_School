CREATE PROCEDURE UpdateStudentFirstName @firstname VARCHAR(50), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Students SET FirstName=@firstname WHERE Email=@searchemail;
END
RETURN 0
