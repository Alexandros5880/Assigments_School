CREATE PROCEDURE UpdateStudentGender @gender VARCHAR(33), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Students SET Gender=@gender WHERE Email=@searchemail;
END
RETURN 0
