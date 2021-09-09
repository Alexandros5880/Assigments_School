CREATE PROCEDURE UpdateStudentPhone @phone VARCHAR(33), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Students SET Phone=@phone WHERE Email=@searchemail;
END
RETURN 0
