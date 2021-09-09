CREATE PROCEDURE UpdateAssignmentsDescription @description VARCHAR(500), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Assignments SET Description=@description WHERE Title=@searchtitle;
END
RETURN 0
