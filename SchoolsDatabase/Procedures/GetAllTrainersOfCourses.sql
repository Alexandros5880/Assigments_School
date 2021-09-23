CREATE PROCEDURE GetAllTrainersOfCourses
@title VARCHAR(100)
AS
BEGIN
SELECT * FROM Trainers tr WHERE Email IN (SELECT TrainerEmail FROM TrainersCourse WHERE CourseTitle=@title);
END
RETURN 0
