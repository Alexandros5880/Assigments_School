CREATE PROCEDURE AddTrainerToCourse @coursetitle VARCHAR(100), @traineremail VARCHAR(100)
AS
BEGIN
DECLARE @course AS VARCHAR(100) = (SELECT Title FROM Courses WHERE Title = @coursetitle),
		@trainer AS VARCHAR(300) = (SELECT Email FROM Trainers WHERE Email = @traineremail)
INSERT INTO TrainersCourse (TrainerEmail, CourseTitle) VALUES (@trainer,@course);
END
RETURN 0
