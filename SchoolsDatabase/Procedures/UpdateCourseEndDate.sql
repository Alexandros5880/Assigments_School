CREATE PROCEDURE UpdateCourseEndDate @enddate VARCHAR(30), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Courses SET EndDate=@enddate WHERE Title=@searchtitle;
END
RETURN 0
