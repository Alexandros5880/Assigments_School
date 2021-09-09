CREATE PROCEDURE UpdateCourse @title VARCHAR(100), @startdate VARCHAR(30), @enddate VARCHAR(30), @description VARCHAR(500), @searchtitle VARCHAR(100)
AS
BEGIN
UPDATE Courses SET Title=@title, StartDate=@startdate, EndDate=@enddate, Description=@description WHERE Title=@searchtitle;
END
RETURN 0
