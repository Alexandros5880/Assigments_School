CREATE PROCEDURE GetAllStudentsOfCourses @title VARCHAR(100)
AS
BEGIN
SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse WHERE CourseTitle=@title);
END
RETURN 0
