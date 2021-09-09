CREATE PROCEDURE DeleteTrainerFromCourse @coursetitle VARCHAR(100), @traineremail VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@trainer AS VARCHAR(300) = (SELECT Email FROM Trainers WHERE Email = @traineremail)
DELETE FROM TrainersCourse WHERE CourseTitle=@course AND TrainerEmail=@trainer;
END
RETURN 0
