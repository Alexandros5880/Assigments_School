CREATE PROCEDURE UpdateCourseTitle @title VARCHAR(100), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Courses SET Title=@title WHERE Title=@searchtitle;
END
RETURN 0
