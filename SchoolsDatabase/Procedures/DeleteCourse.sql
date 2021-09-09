CREATE PROCEDURE DeleteCourse @coursetitle VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle);
DELETE FROM AssignmentsCourse WHERE CourseTitle=@course;
DELETE FROM StudentsCourse WHERE CourseTitle=@course;
DELETE FROM TrainersCourse WHERE CourseTitle=@course;
DELETE FROM Courses WHERE Title=@course;
END
RETURN 0
