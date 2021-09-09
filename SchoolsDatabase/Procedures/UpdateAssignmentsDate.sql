CREATE PROCEDURE UpdateAssignmentsDate @enddate VARCHAR(30), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Assignments SET EndDate=@enddate WHERE Title=@searchtitle;
END
RETURN 0
