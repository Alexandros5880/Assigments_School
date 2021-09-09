CREATE PROCEDURE UpdateAssignmentsTitle @title VARCHAR(100), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Assignments SET Title=@title WHERE Title=@searchtitle;
END
RETURN 0
