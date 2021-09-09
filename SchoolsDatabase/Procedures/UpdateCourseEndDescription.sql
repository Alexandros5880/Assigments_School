CREATE PROCEDURE UpdateCourseEndDescription @description VARCHAR(500), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Courses SET Description=@description WHERE Title=@searchtitle;
END
RETURN 0
